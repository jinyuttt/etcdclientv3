using etcdclientv3.op;
using Grpc.Core;
using System;
using System.Threading;

namespace etcdclientv3.impl
{
    class Util
    {

        private Util()
        {
        }

        /**
         * convert ListenableFuture of Type S to CompletableFuture of Type T.
         */
        public static T ToCompletableFuture<S, T>(S sourceFuture, op.IFunction<S, T> resultConvert)
        {
            return resultConvert.apply(sourceFuture);
        }

        /**
         * converts a ListenableFuture of Type S to a CompletableFuture of Type T with retry on
         * ListenableFuture error.
         *
         * @param newSourceFuture a function that returns a new SourceFuture.
         * @param resultConvert a function that converts Type S to Type T.
         * @param executor a executor.
         * @param <S> Source type
         * @param <T> Converted Type.
         * @return a CompletableFuture with type T.
         */
        public static T ToCompletableFutureWithRetry<S, T>(
               S newSourceFuture,
               IFunction<S, T> resultConvert)
        {
            return ToCompletableFutureWithRetry(newSourceFuture, resultConvert, Util.IsRetriable);
        }

        /**
         * converts a ListenableFuture of Type S to a CompletableFuture of Type T with retry on
         * ListenableFuture error.
         *
         * @param newSourceFuture a function that returns a new SourceFuture.
         * @param resultConvert a function that converts Type S to Type T.
         * @param doRetry a function that determines the retry condition base on SourceFuture error.
         * @param executor a executor.
         * @param <S> Source type
         * @param <T> Converted Type.
         * @return a CompletableFuture with type T.
         */
        public static T ToCompletableFutureWithRetry<S, T>(
               S newSourceFuture,
               IFunction<S, T> resultConvert,
               Function<Exception, bool> doRetry)
        {
            resultConvert.apply(newSourceFuture);
            // only retry 3 times.
            int retryLimit = 3;
            while (retryLimit-- > 0)
            {
                try
                {
                    return resultConvert.apply(newSourceFuture);
                }
                catch (Exception e)
                {
                    if (doRetry(e))
                    {
                        Thread.Sleep(5000);
                    }
                }
            }
            return default(T);
        }

        public static bool IsRetriable(Exception e)
        {
            Status status = new Status(StatusCode.Unknown, e.Message);
            return IsInvalidTokenError(status);
        }

        static bool IsInvalidTokenError(Status status)
        {
            return status.StatusCode == StatusCode.Unauthenticated && "etcdserver: invalid auth token".Equals(status.Detail);
        }



        public static T SupplyIfNull<T>(T target)
        {
            return target != null ? target : default(T);
        }

        public static void AddOnFailureLoggingCallback(ILogger callerLogger, String message)
        {

        }
    }
}
