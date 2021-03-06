﻿using System.Threading.Tasks;
using Utilities;

namespace System.Runtime.CompilerServices
{
    public class AsyncTaskMethodBuilder
    {
        public static readonly Inspector Inspector = new Inspector();

        public static AsyncTaskMethodBuilder LastInstance { get; private set; }

        public Exception Exception { get; private set; }

        public AsyncTaskMethodBuilder()
        {
            Inspector.RecordInvocation();
        }

        public static AsyncTaskMethodBuilder Create() => LastInstance = new AsyncTaskMethodBuilder();

        public void SetException(Exception e)
        {
            Exception = e;
            Inspector.RecordInvocation();
        }

        public Task Task
        {
            get
            {
                Inspector.RecordInvocation();
                return Threading.Tasks.Task.CompletedTask;
            }
        }

        public void SetResult() => Inspector.RecordInvocation();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            Inspector.RecordInvocation();
            stateMachine.MoveNext();
        }

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            Inspector.RecordInvocation();
            stateMachine.MoveNext();
        }

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            Inspector.RecordInvocation();
            stateMachine.MoveNext();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine) =>
            Inspector.RecordInvocation();
    }
}