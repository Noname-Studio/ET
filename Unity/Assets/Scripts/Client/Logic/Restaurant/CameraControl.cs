using System.Threading.Tasks;
using DG.Tweening;
using FairyGUI;
using UnityEngine;

[DefaultExecutionOrder(int.MaxValue)]
public class CameraControl: MonoBehaviour
{
    private UnityBehaviour UnityBehaviour;

    private enum CameraState
    {
        None,
        Drag,
        Scale,
        Press
    }

    [HideInInspector]
    public Camera Camera;

    private Transform mCacheTransform;
    private Transform mBindingCameraTransform;

    public float Speed;
    public float SmoothForce = 2;
    public float SmoothSpeed = 2;
    public float MinSize;
    public float MaxSize;
    public Rect Rect;
    private Vector3 mPreWorldPoint;
    private Vector3 mPreScreenPoint;
    private UnityBehaviour.UpdateData mFollowInstance;
    public static CameraControl Instance;
    private float mBaseScroll;
    private Vector3 mSmoothTarget;
    private float mTime;
    public float FixedZ;
    private const float YScale = 0.81835f;
    public Vector2 CenterOffset = new Vector3(-100f, 82);
    private CameraState mState;

    public bool RectLimit;

    private Vector3 dir = Vector3.zero;

    public Vector3 Position
    {
        get => mCacheTransform.position;
        set => mCacheTransform.position = value;
    }

    private bool mMouseDown, mMouseUp, mMousePress;

    private void Start()
    {
        mCacheTransform = transform;
        Camera = GetComponent<Camera>();
        Instance = this;
        //UnityBehaviour.AddUpdate(Func);
        UpdateCamera();
        //Camera.transparencySortMode = TransparencySortMode.CustomAxis;
        //Camera.transparencySortAxis = new Vector3(1.5f,0,-1.5f);
        UnityBehaviour.AddUpdate(UpdateCamera);
    }

    private void OnDestroy()
    {
        UnityBehaviour.RemoveUpdate(UpdateCamera);
    }

    private float UpdateCamera()
    {
        mMouseDown = false;
        mMousePress = false;
        mMouseUp = false;
        if (Input.GetMouseButtonDown(0) && !Stage.isTouchOnUI)
        {
            mMouseDown = true;
        }
        else if (Input.GetMouseButton(0))
        {
            mMousePress = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mMouseUp = true;
        }

        if (true)
        {
            Smooth();
            Scale();
            Drag();
            ClearState();
        }
        else
        {
            mState = CameraState.None;
        }

        return 0;
    }

    private float ClearState()
    {
        if (mMouseUp || mMouseDown || mMousePress)
        {
            return 0;
        }

        mState = CameraState.None;
        return 0;
    }

    /*public void SetConfig(CameraConfigProperty config)
    {
        Rect = new Rect(config.X, config.Y, config.W, config.Z);
        MinSize = config.ScrollMin;
        MaxSize = config.ScrollMax;
        Camera.orthographicSize = config.ScrollBase;
        mBaseScroll = config.ScrollBase;
    }*/

    /// <summary>
    /// 标准化坐标
    /// 我们应该避免调整Z轴
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static Vector3 CastVector3ToVector2(Vector3 pos, float z)
    {
        //我们通过减去初始的Z值获得增加(减少)的Z的差值
        //然后我们把它添加到X轴中(在此旋转角度下X轴和Z轴方向相反)
        pos.z -= z;
        pos.x += pos.z;
        pos.y -= pos.z * YScale;
        //然后我们把Z轴重新设置回去
        pos.z = z;
        return pos;
    }

    /// <summary>
    /// 标准化坐标
    /// 我们应该避免调整Z轴
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private Vector3 CastVector3ToVector2(Vector3 pos)
    {
        pos = CastVector3ToVector2(pos, FixedZ);
        return pos;
    }

    /// <summary>
    /// 拖拽移动摄像机
    /// </summary>
    private void Drag()
    {
        if (Input.touchCount >= 2)
        {
            return;
        }

        if (Rect.x == 0 && Rect.y == 0 && Rect.width == 0 && Rect.height == 0)
        {
            return;
        }

        var p = Input.mousePosition;
        p.z = 100;
        var currentPoint = Camera.ScreenToWorldPoint(p);
        var point = Camera.ScreenToWorldPoint(mPreScreenPoint) - currentPoint;
        if (mMouseDown)
        {
            dir = Vector3.zero;
            mSmoothTarget = Vector3.zero;
            mState = CameraState.Drag;
        }
        else if (mMousePress && mState == CameraState.Drag)
        {
            var prePos = mCacheTransform.position + point;
            var pos = CastVector3ToVector2(prePos);
            var overflow = ClampOverflow(pos);
            if (overflow != Vector3.zero && RectLimit)
            {
                overflow.x = Mathf.Clamp(0.08f / Mathf.Abs(overflow.x), 0.0005f, 1f);
                overflow.y = Mathf.Clamp(0.08f / Mathf.Abs(overflow.y), 0.0005f, 1f);
                point.x *= overflow.x;
                if (overflow.x >= 0.9f)
                {
                    point.y *= -0.3f + overflow.y;
                }
                else if (overflow.x < 1 && overflow.y < 1)
                {
                    point.y *= 0.001f + overflow.y;
                }
                else
                {
                    point *= overflow.y;
                }

                point.z *= overflow.x;
                var prePos2 = mCacheTransform.position + point;
                var pos2 = CastVector3ToVector2(prePos2);
                mCacheTransform.position = pos2;
            }
            else
            {
                mCacheTransform.position = pos;
            }

            var difference = CastVector3ToVector2(mCacheTransform.position + point) - mCacheTransform.position;
            if (difference != Vector3.zero)
            {
                dir = difference;
            }

            //计算拉力
            //FittingPosition();
        }
        else if (mMouseUp && mState == CameraState.Drag)
        {
            var vec2 = CastVector3ToVector2(mCacheTransform.position);
            //Debugger.Log(dir + "     " + CastVector3ToVector2(Camera.transform.position + point) + "     " + Camera.transform.position);
            if (RectLimit)
            {
                /*var overflow = ClampOverflow(vec2);
                if (overflow != Vector3.zero)
                {
                    mSmoothTarget = DistancePointToRectangle(vec2, Rect);
                }
                else*/
                {
                    point = dir * SmoothForce;
                    point = Vector3.ClampMagnitude(point, 10);
                    mSmoothTarget = DistancePointToRectangle(vec2 + point, Rect);
                }
            }
        }

        mPreScreenPoint = p;

        mTime += Time.deltaTime;
        if (mTime >= 100)
        {
            mTime = 0;
        }

        return;
    }

    public Vector3 DistancePointToRectangle(Vector2 point, Rect rect)
    {
        float minX;
        float maxX;
        float minY;
        float maxY;
        CalcClamp(point, out minX, out maxX, out minY, out maxY);
        //        I   |    II    |  III
        //      ======+==========+======   --yMin
        //       VIII |  IX (in) |  IV
        //      ======+==========+======   --yMax
        //       VII  |    VI    |   V
        if (point.x < minX)
        {
            // Region I, VIII, or VII
            if (point.y < minY)
            {
                // I
                //Debugger.Log("I");
                return new Vector3(minX, minY, FixedZ);
            }
            else if (point.y > maxY)
            {
                // VII
                //Debugger.Log("II");
                return new Vector3(minX, maxY, FixedZ);
            }
            else
            {
                // VIII
                //Debugger.Log("VIII");
                return new Vector3(minX, point.y, FixedZ);
            }
        }
        else if (point.x > maxX)
        {
            // Region III, IV, or V
            if (point.y < minY)
            {
                // III
                //Debugger.Log("III");
                return new Vector3(maxX, minY, FixedZ);
            }
            else if (point.y > maxY)
            {
                // V
                //Debugger.Log("V");
                return new Vector3(maxX, maxY, FixedZ);
            }
            else
            {
                // IV
                //Debugger.Log("IV");
                return new Vector3(maxX, point.y, FixedZ);
            }
        }
        else
        {
            // Region II, IX, or VI
            if (point.y < minY)
            {
                // II
                //Debugger.Log("II");
                return new Vector3(point.x, minY, FixedZ);
            }
            else if (point.y > maxY)
            {
                // VI
                //Debugger.Log("VI");
                return new Vector3(point.x, maxY, FixedZ);
            }
            else
            {
                // IX
                //Debugger.Log("IX");
                return new Vector3(point.x, point.y, FixedZ);
            }
        }
    }

    private void CalcClamp(Vector2 point, out float minX, out float maxX, out float minY, out float maxY)
    {
        var vertExtent = Camera.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;
        minX = Rect.x + horzExtent;
        maxX = Rect.width - horzExtent;
        float center = (minX + maxX) / 2;

        float perc = Mathf.Abs(Mathf.Clamp(point.x, minX, maxX) - center) * 0.41f;
        if (point.x > center)
        {
            minY = Rect.y - perc - (mBaseScroll - vertExtent) * 1.2f;
            maxY = Rect.height - perc - (mBaseScroll - vertExtent) * -1.2f;
        }
        else
        {
            minY = Rect.y + perc - (mBaseScroll - vertExtent) * 1.2f;
            maxY = Rect.height + perc - (mBaseScroll - vertExtent) * -1.2f;
        }
    }

    private void Smooth()
    {
        if (mMouseUp || mMouseDown || mMousePress || Input.touchCount > 0)
        {
            return;
        }

        if (mSmoothTarget != Vector3.zero)
        {
            mCacheTransform.position = Vector3.Lerp(mCacheTransform.position, mSmoothTarget, Time.deltaTime * SmoothSpeed);
            if (Vector3.SqrMagnitude(mCacheTransform.position - mSmoothTarget) <= 0.0001f)
            {
                mCacheTransform.position = mSmoothTarget;
                mSmoothTarget = Vector3.zero;
            }
        }

        return;
    }

    private bool wasZoomingLastFrame;
    private Vector2[] lastZoomPositions;

    private void Scale()
    {
        if (Stage.isTouchOnUI)
        {
            return;
        }
#if UNITY_EDITOR
        if (Input.mouseScrollDelta.y == 0)
        {
            return;
        }

        Camera.orthographicSize -= Input.mouseScrollDelta.y * 0.5f;
        mSmoothTarget = Vector3.zero;
#else
		if (Input.touchCount >= 2)
		{
			mState = CameraState.Scale;
			Vector2[] newPositions = new Vector2[]{Input.GetTouch(0).position, Input.GetTouch(1).position};
			if (!wasZoomingLastFrame) {
				lastZoomPositions = newPositions;
				wasZoomingLastFrame = true;
			} else {
				float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
				float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
				float offset = newDistance - oldDistance;
				Camera.orthographicSize -= offset / 50;

				lastZoomPositions = newPositions;
			}
			mSmoothTarget = Vector3.zero;
		}
		else
		{
			wasZoomingLastFrame = false;
			return;
		}
#endif

        if (Camera.orthographicSize <= MinSize)
        {
            Camera.orthographicSize = MinSize;
        }
        else if (Camera.orthographicSize >= MaxSize)
        {
            Camera.orthographicSize = MaxSize;
        }

        /*if (Camera.orthographicSize <= TransparentSize && IsAlpha == false)
        {
            for (int i = 0; i < TransparentObject.Length; i++)
            {
                Renderer renderer = TransparentObject[i];
                DOTween.ToAlpha(()=> renderer.material.color, value => renderer.material.color = value, -1, TransparentTime);
            }
            IsAlpha = true;
        }
        else if (IsAlpha)
        {
            for (int i = 0; i < TransparentObject.Length; i++)
            {
                Renderer renderer = TransparentObject[i];
                DOTween.ToAlpha(()=> renderer.material.color, value => renderer.material.color = value, 1, TransparentTime);
            }

            IsAlpha = false;
        }*/
        if (RectLimit)
        {
            FittingPosition();
        }

        return;
    }

    private void FittingPosition()
    {
        Vector3? v3 = ClampPosition(mCacheTransform.position);
        if (!v3.HasValue)
        {
            return;
        }

        mCacheTransform.position = v3.Value;
    }

    private Vector3? ClampPosition(Vector3 v3)
    {
        if (Rect.x == 0 && Rect.y == 0 && Rect.width == 0 && Rect.height == 0)
        {
            return null;
        }

        float minX;
        float maxX;
        float minY;
        float maxY;
        CalcClamp(v3, out minX, out maxX, out minY, out maxY);
        //		Debugger.Log(minX + "    " + maxX + "    " + minY + "     " + maxY);
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        return v3;
    }

    private Vector3 ClampOverflow(Vector3 v3)
    {
        var pos = ClampPosition(v3);
        if (pos.HasValue)
        {
            return pos.Value - v3;
        }

        return Vector3.zero;
    }

    /// <summary>
    /// 移动到目标点
    /// </summary>
    /// <param name="point">点</param>
    /// <param name="lerp">缓动</param>
    public void Follow(Transform target, bool lerp = true, Vector3? offset = null)
    {
        if (mFollowInstance != null)
        {
            UnityBehaviour.RemoveUpdate(mFollowInstance);
        }

        mFollowInstance = UnityBehaviour.AddUpdate(() => InternalFollow(target, lerp, offset == null? Vector3.zero : offset.Value));
    }

    public void RemoveFollow()
    {
        if (mFollowInstance != null)
        {
            UnityBehaviour.RemoveUpdate(mFollowInstance);
        }
    }

    private float InternalFollow(Transform target, bool lerp, Vector3 offset)
    {
        var pos = target.position;
        pos = CastVector3ToVector2(pos, 0);
        pos.x += CenterOffset.x;
        pos.y += CenterOffset.y;
        pos.z = FixedZ;
        if (lerp)
        {
            mCacheTransform.position = Vector3.Lerp(mCacheTransform.position, pos + offset, 0.15f);
        }
        else
        {
            mCacheTransform.position = pos + offset;
        }

        return 0;
    }

    public void ResetSize()
    {
        Camera.main.DOOrthoSize(4, 0.8f);
    }
}