using System.Collections;
using System.Collections.Generic;
using Kitchen;
using UnityEngine;

public class KitchenSpotProvider
{
    private List<AKitchenSpot> mSpots = new List<AKitchenSpot>();
    private List<AKitchenSpot> mFreeSpots = new List<AKitchenSpot>();
    public void AddSpot(AKitchenSpot spot)
    {
        mSpots.Add(spot);
        mFreeSpots.Add(spot);
    }

    public void RemoveSpot(AKitchenSpot spot)
    {
        mSpots.Remove(spot);
        mFreeSpots.Remove(spot);
    }

    public int TotalCount()
    {
        return mSpots.Count;
    }

    public int FreeSpotCount()
    {
        return mFreeSpots.Count;
    }
    
    public void LockSpot(AKitchenSpot spot,ACustomer customer)
    {
        spot.SetState(KitchenSpotState.Busy);
        spot.SetCustomer(customer);
        mFreeSpots.Remove(spot);
    }

    public void ReleaseSpot(AKitchenSpot spot)
    {
        spot.SetState(KitchenSpotState.Free);
        spot.SetCustomer(null);
        mFreeSpots.Add(spot);
    }

    public AKitchenSpot GetSpot(Vector3 pos)
    {
        foreach (var node in mSpots)
        {
            if (node.Position == pos)
                return node;
        }
        return null;
    }
    
    public AKitchenSpot GetSpot(int index)
    {
        if (index >= 0 && mSpots.Count > index) 
            return mSpots[index];
        return null;
    }
    
    public bool AnyFree()
    {
        return mFreeSpots.Count > 0;
    }
    
    public AKitchenSpot GetFreeSpot()
    {
        return mFreeSpots[Random.Range(0, mFreeSpots.Count)];
    }
}
