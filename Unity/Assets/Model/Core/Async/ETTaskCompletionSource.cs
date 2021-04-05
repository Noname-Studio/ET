﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace ET
{
    public class ETTaskCompletionSource: ICriticalNotifyCompletion
    {
        private AwaiterStatus state;
        private ExceptionDispatchInfo exception;
        private Action continuation; // action or list

        [DebuggerHidden]
        public ETTask Task => new ETTask(this);

        [DebuggerHidden]
        public AwaiterStatus Status => state;

        [DebuggerHidden]
        public bool IsCompleted => state != AwaiterStatus.Pending;

        [DebuggerHidden]
        public void UnsafeOnCompleted(Action action)
        {
            continuation = action;
            if (state != AwaiterStatus.Pending)
            {
                TryInvokeContinuation();
            }
        }

        [DebuggerHidden]
        public void OnCompleted(Action action)
        {
            UnsafeOnCompleted(action);
        }

        [DebuggerHidden]
        public void GetResult()
        {
            switch (state)
            {
                case AwaiterStatus.Succeeded:
                    return;
                case AwaiterStatus.Faulted:
                    exception?.Throw();
                    exception = null;
                    return;
                default:
                    throw new NotSupportedException("ETTask does not allow call GetResult directly when task not completed. Please use 'await'.");
            }
        }

        [DebuggerHidden]
        public void SetResult()
        {
            if (TrySetResult())
            {
                return;
            }

            throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }

        [DebuggerHidden]
        public void SetException(Exception e)
        {
            if (TrySetException(e))
            {
                return;
            }

            throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }

        [DebuggerHidden]
        private void TryInvokeContinuation()
        {
            continuation?.Invoke();
            continuation = null;
        }

        [DebuggerHidden]
        private bool TrySetResult()
        {
            if (state != AwaiterStatus.Pending)
            {
                return false;
            }

            state = AwaiterStatus.Succeeded;

            TryInvokeContinuation();
            return true;
        }

        [DebuggerHidden]
        private bool TrySetException(Exception e)
        {
            if (state != AwaiterStatus.Pending)
            {
                return false;
            }

            state = AwaiterStatus.Faulted;

            exception = ExceptionDispatchInfo.Capture(e);
            TryInvokeContinuation();
            return true;
        }
    }

    public class ETTaskCompletionSource<T>: ICriticalNotifyCompletion
    {
        private AwaiterStatus state;
        private T value;
        private ExceptionDispatchInfo exception;
        private Action continuation; // action or list

        [DebuggerHidden]
        public ETTask<T> Task => new ETTask<T>(this);

        [DebuggerHidden]
        public ETTaskCompletionSource<T> GetAwaiter()
        {
            return this;
        }

        [DebuggerHidden]
        public T GetResult()
        {
            switch (state)
            {
                case AwaiterStatus.Succeeded:
                    return value;
                case AwaiterStatus.Faulted:
                    exception?.Throw();
                    exception = null;
                    return default;
                default:
                    throw new NotSupportedException("ETask does not allow call GetResult directly when task not completed. Please use 'await'.");
            }
        }

        [DebuggerHidden]
        public bool IsCompleted => state != AwaiterStatus.Pending;

        [DebuggerHidden]
        public AwaiterStatus Status => state;

        [DebuggerHidden]
        public void UnsafeOnCompleted(Action action)
        {
            continuation = action;
            if (state != AwaiterStatus.Pending)
            {
                TryInvokeContinuation();
            }
        }

        [DebuggerHidden]
        public void OnCompleted(Action action)
        {
            UnsafeOnCompleted(action);
        }

        [DebuggerHidden]
        public void SetResult(T result)
        {
            if (TrySetResult(result))
            {
                return;
            }

            throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }

        [DebuggerHidden]
        public void SetException(Exception e)
        {
            if (TrySetException(e))
            {
                return;
            }

            throw new InvalidOperationException("TaskT_TransitionToFinal_AlreadyCompleted");
        }

        [DebuggerHidden]
        private void TryInvokeContinuation()
        {
            continuation?.Invoke();
            continuation = null;
        }

        [DebuggerHidden]
        private bool TrySetResult(T result)
        {
            if (state != AwaiterStatus.Pending)
            {
                return false;
            }

            state = AwaiterStatus.Succeeded;

            value = result;
            TryInvokeContinuation();
            return true;
        }

        [DebuggerHidden]
        private bool TrySetException(Exception e)
        {
            if (state != AwaiterStatus.Pending)
            {
                return false;
            }

            state = AwaiterStatus.Faulted;

            exception = ExceptionDispatchInfo.Capture(e);
            TryInvokeContinuation();
            return true;
        }
    }
}