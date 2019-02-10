using etcdclientv3.IEtcdClient;
using Etcdserverpb;
using System;
using System.Collections.Generic;

namespace etcdclientv3.op
{

    public class TxnImpl : ITxn {

  public static TxnImpl newTxn(IFunction<TxnRequest, KV.TxnResponse> f) {
    return new TxnImpl(f);
  }

  private List<Cmp<object>> cmpList = new List<Cmp<object>>();
  private List<Op> successOpList = new List<Op>();
  private List<Op> failureOpList = new List<Op>();
  private IFunction<TxnRequest, KV.TxnResponse> requestF;

  private bool seenThen = false;
  private bool seenElse = false;

  private TxnImpl(IFunction<TxnRequest, KV.TxnResponse>  f) {
    this.requestF = f;
  }

  //CHECKSTYLE:OFF
  //public TxnImpl If(params  Cmp cmps) {
  //  //CHECKSTYLE:ON
   
  //}

  //CHECKSTYLE:OFF
  TxnImpl If(List<Cmp<object>> cmps) {
    //CHECKSTYLE:ON
    if (this.seenThen) {
      throw new Exception("cannot call If after Then!");
    }
            if (this.seenElse)
            {
                throw new Exception("cannot call If after Else!");
            }
            cmpList.AddRange(cmps);
    return this;
  }

  //CHECKSTYLE:OFF
  //public TxnImpl Then(params Op ops) {
  //  //CHECKSTYLE:ON
  // // return Then(ImmutableList.copyOf(ops));
  //}

  //CHECKSTYLE:OFF
  TxnImpl Then(List<Op> ops) {
    //CHECKSTYLE:ON
    if (this.seenElse) {
      throw new Exception("cannot call Then after Else!");
    }

    this.seenThen = true;

    successOpList.AddRange(ops);
    return this;
  }

        //CHECKSTYLE:OFF
        //public TxnImpl Else(params Op ops)
        //{
        //    CHECKSTYLE: ON
        //  return Else(ImmutableList.copyOf(ops));
        //}

        //CHECKSTYLE:OFF
        TxnImpl Else(List<Op> ops) {
    //CHECKSTYLE:ON
    this.seenElse = true;

    failureOpList.AddRange(ops);
    return this;
  }

  private TxnRequest ToTxnRequest() {
            TxnRequest requestBuilder =new TxnRequest();

            foreach (Cmp<object> c in this.cmpList)
            {
                requestBuilder.Compare.Add(c.ToCompare());
            }
            foreach (Op o in this.successOpList)
            {
                requestBuilder.Success.Add(o.ToRequestOp());
            }
           
            foreach (Op o in this.failureOpList) {
          requestBuilder.Failure.Add(o.ToRequestOp());
    }

            return requestBuilder;
  }

        public ITxn If(params Cmp<object>[] cmps)
        {
            //
            return If(new List<Cmp<object>>(cmps));
        }

        public ITxn Then(params Op[] ops)
        {
            return Then(new List<Op>(ops));
        }

        public ITxn Else(params Op[] ops)
        {
            return Else(new List<Op>(ops));
        }

        public KV.TxnResponse Commit()
        {
            return this.requestF.apply(this.ToTxnRequest());
        }
    }
}
