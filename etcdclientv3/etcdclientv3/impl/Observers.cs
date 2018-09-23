//namespace etcdclientv3.impl
//{ 

//public   class Observers {
//  private Observers() {
//  }

//  public static V StreamObserver<V> observer<V>(Consumer<V> onNext) {
//         return   default(V);
//  }

//  public static  StreamObserver<V> observer(Consumer<V> onNext, Consumer<Throwable> onError) {
    
//  }

//  public static <T, V> StreamObserver<T> observe(
//      Function<StreamObserver<V>, StreamObserver<T>> consumer,
//      Consumer<V> onNext,
//      Consumer<Throwable> onError) {

//    return consumer.apply(
//      observer(onNext, onError)
//    );
//  }

//  public static <T> Builder<T> builder() {
//    return new Builder<>();
//  }

//  public static   class Builder<V> {
//    private Consumer<V> onNext;
//    private Consumer<Throwable> onError;
//    private Runnable onCompleted;

//    public Builder<V> onNext(Consumer<V> onNext) {
//      this.onNext = onNext;
//      return this;
//    }

//    public Builder<V> onError(Consumer<Throwable> onError) {
//      this.onError = onError;
//      return this;
//    }

//    public Builder<V> onCompleted(Runnable onCompleted) {
//      this.onCompleted = onCompleted;
//      return this;
//    }

//    public StreamObserver<V> build() {
//        Consumer<V> doOnNext = this.onNext;
//        Consumer<Throwable> doOnnError = this.onError;
//        Runnable doOnnCompleted = this.onCompleted;

//      return new StreamObserver<V>() {
         
//        public void onNext(V value) {
//          if (onNext != null) {
//            doOnNext.accept(value);
//          }
//        }

         
//        public void onError(Throwable throwable) {
//          if (doOnnError != null) {
//            doOnnError.accept(throwable);
//          }
//        }

         
//        public void onCompleted() {
//          if (doOnnCompleted != null) {
//            doOnnCompleted.run();
//          }
//        }
//      };
//    }

//  }
//}
//}
