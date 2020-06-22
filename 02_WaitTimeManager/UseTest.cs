

//3秒后执行
Coroutine coroutine = WaitTimeManager.WaitTime(3, () =>
{
   //to do
});

//等待过程中执行以下语句，则取消执行
WaitTimeManager.CancelWait(ref coroutine);