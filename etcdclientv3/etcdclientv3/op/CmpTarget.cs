using etcdclientv3.data;
using Etcdserverpb;
using Google.Protobuf;

namespace etcdclientv3.op
{ 
public abstract class CmpTarget<T> {

  /**
   * Cmp on a given <i>version</i>.
   *
   * @param version version to compare
   * @return the version compare target
   */
  public static VersionCmpTarget Version(long version) {
    return new VersionCmpTarget(version);
  }

  /**
   * Cmp on the create <i>revision</i>.
   *
   * @param revision the create revision
   * @return the create revision compare target
   */
  public static CreateRevisionCmpTarget CreateRevision(long revision) {
    return new CreateRevisionCmpTarget(revision);
  }

  /**
   * Cmp on the modification <i>revision</i>.
   *
   * @param revision the modification revision
   * @return the modification revision compare target
   */
  public static ModRevisionCmpTarget modRevision(long revision) {
    return new ModRevisionCmpTarget(revision);
  }

  /**
   * Cmp on the <i>value</i>.
   *
   * @param value the value to compare
   * @return the value compare target
   */
  public static ValueCmpTarget Value(ByteSequence value) {
    return new ValueCmpTarget(ByteString.CopyFrom(value.getBytes()));
  }

  private  Compare.Types.CompareTarget target;
  private  T targetValue;

  protected CmpTarget(Compare.Types.CompareTarget target, T targetValue) {
    this.target = target;
    this.targetValue = targetValue;
  }

  /**
   * Get the compare target used for this compare.
   *
   * @return the compare target used for this compare
   */
  public Compare.Types.CompareTarget getTarget() {
    return target;
  }

  /**
   * Get the compare target value of this compare.
   *
   * @return the compare target value of this compare.
   */
  public T getTargetValue() {
    return targetValue;
  }
 
        public class VersionCmpTarget : CmpTarget<long> {
            public VersionCmpTarget(long targetValue): base(Compare.Types.CompareTarget.Version, targetValue)
            {
            }
  }

        public class CreateRevisionCmpTarget : CmpTarget<long> {

       public CreateRevisionCmpTarget(long targetValue):base(Compare.Types.CompareTarget.Create, targetValue) {
     
    }
  }

        public class ModRevisionCmpTarget : CmpTarget<long> {

   public ModRevisionCmpTarget(long targetValue):base(Compare.Types.CompareTarget.Mod, targetValue) {
      
    }
  }

  public   class ValueCmpTarget : CmpTarget<ByteString> {

  public  ValueCmpTarget(ByteString targetValue):base(Compare.Types.CompareTarget.Value,targetValue) {
   
    }
  }

}
}
