// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: auth.proto

package io.etcd.jetcd.api;

/**
 * <pre>
 * Permission is a single entity
 * </pre>
 *
 * Protobuf type {@code authpb.Permission}
 */
public  final class Permission extends
    com.google.protobuf.GeneratedMessageV3 implements
    // @@protoc_insertion_point(message_implements:authpb.Permission)
    PermissionOrBuilder {
private static final long serialVersionUID = 0L;
  // Use Permission.newBuilder() to construct.
  private Permission(com.google.protobuf.GeneratedMessageV3.Builder<?> builder) {
    super(builder);
  }
  private Permission() {
    permType_ = 0;
    key_ = com.google.protobuf.ByteString.EMPTY;
    rangeEnd_ = com.google.protobuf.ByteString.EMPTY;
  }

  @java.lang.Override
  public final com.google.protobuf.UnknownFieldSet
  getUnknownFields() {
    return this.unknownFields;
  }
  private Permission(
      com.google.protobuf.CodedInputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    this();
    if (extensionRegistry == null) {
      throw new java.lang.NullPointerException();
    }
    int mutable_bitField0_ = 0;
    com.google.protobuf.UnknownFieldSet.Builder unknownFields =
        com.google.protobuf.UnknownFieldSet.newBuilder();
    try {
      boolean done = false;
      while (!done) {
        int tag = input.readTag();
        switch (tag) {
          case 0:
            done = true;
            break;
          case 8: {
            int rawValue = input.readEnum();

            permType_ = rawValue;
            break;
          }
          case 18: {

            key_ = input.readBytes();
            break;
          }
          case 26: {

            rangeEnd_ = input.readBytes();
            break;
          }
          default: {
            if (!parseUnknownFieldProto3(
                input, unknownFields, extensionRegistry, tag)) {
              done = true;
            }
            break;
          }
        }
      }
    } catch (com.google.protobuf.InvalidProtocolBufferException e) {
      throw e.setUnfinishedMessage(this);
    } catch (java.io.IOException e) {
      throw new com.google.protobuf.InvalidProtocolBufferException(
          e).setUnfinishedMessage(this);
    } finally {
      this.unknownFields = unknownFields.build();
      makeExtensionsImmutable();
    }
  }
  public static final com.google.protobuf.Descriptors.Descriptor
      getDescriptor() {
    return io.etcd.jetcd.api.Auth.internal_static_authpb_Permission_descriptor;
  }

  @java.lang.Override
  protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
      internalGetFieldAccessorTable() {
    return io.etcd.jetcd.api.Auth.internal_static_authpb_Permission_fieldAccessorTable
        .ensureFieldAccessorsInitialized(
            io.etcd.jetcd.api.Permission.class, io.etcd.jetcd.api.Permission.Builder.class);
  }

  /**
   * Protobuf enum {@code authpb.Permission.Type}
   */
  public enum Type
      implements com.google.protobuf.ProtocolMessageEnum {
    /**
     * <code>READ = 0;</code>
     */
    READ(0),
    /**
     * <code>WRITE = 1;</code>
     */
    WRITE(1),
    /**
     * <code>READWRITE = 2;</code>
     */
    READWRITE(2),
    UNRECOGNIZED(-1),
    ;

    /**
     * <code>READ = 0;</code>
     */
    public static final int READ_VALUE = 0;
    /**
     * <code>WRITE = 1;</code>
     */
    public static final int WRITE_VALUE = 1;
    /**
     * <code>READWRITE = 2;</code>
     */
    public static final int READWRITE_VALUE = 2;


    public final int getNumber() {
      if (this == UNRECOGNIZED) {
        throw new java.lang.IllegalArgumentException(
            "Can't get the number of an unknown enum value.");
      }
      return value;
    }

    /**
     * @deprecated Use {@link #forNumber(int)} instead.
     */
    @java.lang.Deprecated
    public static Type valueOf(int value) {
      return forNumber(value);
    }

    public static Type forNumber(int value) {
      switch (value) {
        case 0: return READ;
        case 1: return WRITE;
        case 2: return READWRITE;
        default: return null;
      }
    }

    public static com.google.protobuf.Internal.EnumLiteMap<Type>
        internalGetValueMap() {
      return internalValueMap;
    }
    private static final com.google.protobuf.Internal.EnumLiteMap<
        Type> internalValueMap =
          new com.google.protobuf.Internal.EnumLiteMap<Type>() {
            public Type findValueByNumber(int number) {
              return Type.forNumber(number);
            }
          };

    public final com.google.protobuf.Descriptors.EnumValueDescriptor
        getValueDescriptor() {
      return getDescriptor().getValues().get(ordinal());
    }
    public final com.google.protobuf.Descriptors.EnumDescriptor
        getDescriptorForType() {
      return getDescriptor();
    }
    public static final com.google.protobuf.Descriptors.EnumDescriptor
        getDescriptor() {
      return io.etcd.jetcd.api.Permission.getDescriptor().getEnumTypes().get(0);
    }

    private static final Type[] VALUES = values();

    public static Type valueOf(
        com.google.protobuf.Descriptors.EnumValueDescriptor desc) {
      if (desc.getType() != getDescriptor()) {
        throw new java.lang.IllegalArgumentException(
          "EnumValueDescriptor is not for this type.");
      }
      if (desc.getIndex() == -1) {
        return UNRECOGNIZED;
      }
      return VALUES[desc.getIndex()];
    }

    private final int value;

    private Type(int value) {
      this.value = value;
    }

    // @@protoc_insertion_point(enum_scope:authpb.Permission.Type)
  }

  public static final int PERMTYPE_FIELD_NUMBER = 1;
  private int permType_;
  /**
   * <code>.authpb.Permission.Type permType = 1;</code>
   */
  public int getPermTypeValue() {
    return permType_;
  }
  /**
   * <code>.authpb.Permission.Type permType = 1;</code>
   */
  public io.etcd.jetcd.api.Permission.Type getPermType() {
    @SuppressWarnings("deprecation")
    io.etcd.jetcd.api.Permission.Type result = io.etcd.jetcd.api.Permission.Type.valueOf(permType_);
    return result == null ? io.etcd.jetcd.api.Permission.Type.UNRECOGNIZED : result;
  }

  public static final int KEY_FIELD_NUMBER = 2;
  private com.google.protobuf.ByteString key_;
  /**
   * <code>bytes key = 2;</code>
   */
  public com.google.protobuf.ByteString getKey() {
    return key_;
  }

  public static final int RANGE_END_FIELD_NUMBER = 3;
  private com.google.protobuf.ByteString rangeEnd_;
  /**
   * <code>bytes range_end = 3;</code>
   */
  public com.google.protobuf.ByteString getRangeEnd() {
    return rangeEnd_;
  }

  private byte memoizedIsInitialized = -1;
  @java.lang.Override
  public final boolean isInitialized() {
    byte isInitialized = memoizedIsInitialized;
    if (isInitialized == 1) return true;
    if (isInitialized == 0) return false;

    memoizedIsInitialized = 1;
    return true;
  }

  @java.lang.Override
  public void writeTo(com.google.protobuf.CodedOutputStream output)
                      throws java.io.IOException {
    if (permType_ != io.etcd.jetcd.api.Permission.Type.READ.getNumber()) {
      output.writeEnum(1, permType_);
    }
    if (!key_.isEmpty()) {
      output.writeBytes(2, key_);
    }
    if (!rangeEnd_.isEmpty()) {
      output.writeBytes(3, rangeEnd_);
    }
    unknownFields.writeTo(output);
  }

  @java.lang.Override
  public int getSerializedSize() {
    int size = memoizedSize;
    if (size != -1) return size;

    size = 0;
    if (permType_ != io.etcd.jetcd.api.Permission.Type.READ.getNumber()) {
      size += com.google.protobuf.CodedOutputStream
        .computeEnumSize(1, permType_);
    }
    if (!key_.isEmpty()) {
      size += com.google.protobuf.CodedOutputStream
        .computeBytesSize(2, key_);
    }
    if (!rangeEnd_.isEmpty()) {
      size += com.google.protobuf.CodedOutputStream
        .computeBytesSize(3, rangeEnd_);
    }
    size += unknownFields.getSerializedSize();
    memoizedSize = size;
    return size;
  }

  @java.lang.Override
  public boolean equals(final java.lang.Object obj) {
    if (obj == this) {
     return true;
    }
    if (!(obj instanceof io.etcd.jetcd.api.Permission)) {
      return super.equals(obj);
    }
    io.etcd.jetcd.api.Permission other = (io.etcd.jetcd.api.Permission) obj;

    boolean result = true;
    result = result && permType_ == other.permType_;
    result = result && getKey()
        .equals(other.getKey());
    result = result && getRangeEnd()
        .equals(other.getRangeEnd());
    result = result && unknownFields.equals(other.unknownFields);
    return result;
  }

  @java.lang.Override
  public int hashCode() {
    if (memoizedHashCode != 0) {
      return memoizedHashCode;
    }
    int hash = 41;
    hash = (19 * hash) + getDescriptor().hashCode();
    hash = (37 * hash) + PERMTYPE_FIELD_NUMBER;
    hash = (53 * hash) + permType_;
    hash = (37 * hash) + KEY_FIELD_NUMBER;
    hash = (53 * hash) + getKey().hashCode();
    hash = (37 * hash) + RANGE_END_FIELD_NUMBER;
    hash = (53 * hash) + getRangeEnd().hashCode();
    hash = (29 * hash) + unknownFields.hashCode();
    memoizedHashCode = hash;
    return hash;
  }

  public static io.etcd.jetcd.api.Permission parseFrom(
      java.nio.ByteBuffer data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(
      java.nio.ByteBuffer data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(
      com.google.protobuf.ByteString data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(
      com.google.protobuf.ByteString data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(byte[] data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(
      byte[] data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input, extensionRegistry);
  }
  public static io.etcd.jetcd.api.Permission parseDelimitedFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input);
  }
  public static io.etcd.jetcd.api.Permission parseDelimitedFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input, extensionRegistry);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(
      com.google.protobuf.CodedInputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static io.etcd.jetcd.api.Permission parseFrom(
      com.google.protobuf.CodedInputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input, extensionRegistry);
  }

  @java.lang.Override
  public Builder newBuilderForType() { return newBuilder(); }
  public static Builder newBuilder() {
    return DEFAULT_INSTANCE.toBuilder();
  }
  public static Builder newBuilder(io.etcd.jetcd.api.Permission prototype) {
    return DEFAULT_INSTANCE.toBuilder().mergeFrom(prototype);
  }
  @java.lang.Override
  public Builder toBuilder() {
    return this == DEFAULT_INSTANCE
        ? new Builder() : new Builder().mergeFrom(this);
  }

  @java.lang.Override
  protected Builder newBuilderForType(
      com.google.protobuf.GeneratedMessageV3.BuilderParent parent) {
    Builder builder = new Builder(parent);
    return builder;
  }
  /**
   * <pre>
   * Permission is a single entity
   * </pre>
   *
   * Protobuf type {@code authpb.Permission}
   */
  public static final class Builder extends
      com.google.protobuf.GeneratedMessageV3.Builder<Builder> implements
      // @@protoc_insertion_point(builder_implements:authpb.Permission)
      io.etcd.jetcd.api.PermissionOrBuilder {
    public static final com.google.protobuf.Descriptors.Descriptor
        getDescriptor() {
      return io.etcd.jetcd.api.Auth.internal_static_authpb_Permission_descriptor;
    }

    @java.lang.Override
    protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
        internalGetFieldAccessorTable() {
      return io.etcd.jetcd.api.Auth.internal_static_authpb_Permission_fieldAccessorTable
          .ensureFieldAccessorsInitialized(
              io.etcd.jetcd.api.Permission.class, io.etcd.jetcd.api.Permission.Builder.class);
    }

    // Construct using io.etcd.jetcd.api.Permission.newBuilder()
    private Builder() {
      maybeForceBuilderInitialization();
    }

    private Builder(
        com.google.protobuf.GeneratedMessageV3.BuilderParent parent) {
      super(parent);
      maybeForceBuilderInitialization();
    }
    private void maybeForceBuilderInitialization() {
      if (com.google.protobuf.GeneratedMessageV3
              .alwaysUseFieldBuilders) {
      }
    }
    @java.lang.Override
    public Builder clear() {
      super.clear();
      permType_ = 0;

      key_ = com.google.protobuf.ByteString.EMPTY;

      rangeEnd_ = com.google.protobuf.ByteString.EMPTY;

      return this;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.Descriptor
        getDescriptorForType() {
      return io.etcd.jetcd.api.Auth.internal_static_authpb_Permission_descriptor;
    }

    @java.lang.Override
    public io.etcd.jetcd.api.Permission getDefaultInstanceForType() {
      return io.etcd.jetcd.api.Permission.getDefaultInstance();
    }

    @java.lang.Override
    public io.etcd.jetcd.api.Permission build() {
      io.etcd.jetcd.api.Permission result = buildPartial();
      if (!result.isInitialized()) {
        throw newUninitializedMessageException(result);
      }
      return result;
    }

    @java.lang.Override
    public io.etcd.jetcd.api.Permission buildPartial() {
      io.etcd.jetcd.api.Permission result = new io.etcd.jetcd.api.Permission(this);
      result.permType_ = permType_;
      result.key_ = key_;
      result.rangeEnd_ = rangeEnd_;
      onBuilt();
      return result;
    }

    @java.lang.Override
    public Builder clone() {
      return (Builder) super.clone();
    }
    @java.lang.Override
    public Builder setField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        java.lang.Object value) {
      return (Builder) super.setField(field, value);
    }
    @java.lang.Override
    public Builder clearField(
        com.google.protobuf.Descriptors.FieldDescriptor field) {
      return (Builder) super.clearField(field);
    }
    @java.lang.Override
    public Builder clearOneof(
        com.google.protobuf.Descriptors.OneofDescriptor oneof) {
      return (Builder) super.clearOneof(oneof);
    }
    @java.lang.Override
    public Builder setRepeatedField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        int index, java.lang.Object value) {
      return (Builder) super.setRepeatedField(field, index, value);
    }
    @java.lang.Override
    public Builder addRepeatedField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        java.lang.Object value) {
      return (Builder) super.addRepeatedField(field, value);
    }
    @java.lang.Override
    public Builder mergeFrom(com.google.protobuf.Message other) {
      if (other instanceof io.etcd.jetcd.api.Permission) {
        return mergeFrom((io.etcd.jetcd.api.Permission)other);
      } else {
        super.mergeFrom(other);
        return this;
      }
    }

    public Builder mergeFrom(io.etcd.jetcd.api.Permission other) {
      if (other == io.etcd.jetcd.api.Permission.getDefaultInstance()) return this;
      if (other.permType_ != 0) {
        setPermTypeValue(other.getPermTypeValue());
      }
      if (other.getKey() != com.google.protobuf.ByteString.EMPTY) {
        setKey(other.getKey());
      }
      if (other.getRangeEnd() != com.google.protobuf.ByteString.EMPTY) {
        setRangeEnd(other.getRangeEnd());
      }
      this.mergeUnknownFields(other.unknownFields);
      onChanged();
      return this;
    }

    @java.lang.Override
    public final boolean isInitialized() {
      return true;
    }

    @java.lang.Override
    public Builder mergeFrom(
        com.google.protobuf.CodedInputStream input,
        com.google.protobuf.ExtensionRegistryLite extensionRegistry)
        throws java.io.IOException {
      io.etcd.jetcd.api.Permission parsedMessage = null;
      try {
        parsedMessage = PARSER.parsePartialFrom(input, extensionRegistry);
      } catch (com.google.protobuf.InvalidProtocolBufferException e) {
        parsedMessage = (io.etcd.jetcd.api.Permission) e.getUnfinishedMessage();
        throw e.unwrapIOException();
      } finally {
        if (parsedMessage != null) {
          mergeFrom(parsedMessage);
        }
      }
      return this;
    }

    private int permType_ = 0;
    /**
     * <code>.authpb.Permission.Type permType = 1;</code>
     */
    public int getPermTypeValue() {
      return permType_;
    }
    /**
     * <code>.authpb.Permission.Type permType = 1;</code>
     */
    public Builder setPermTypeValue(int value) {
      permType_ = value;
      onChanged();
      return this;
    }
    /**
     * <code>.authpb.Permission.Type permType = 1;</code>
     */
    public io.etcd.jetcd.api.Permission.Type getPermType() {
      @SuppressWarnings("deprecation")
      io.etcd.jetcd.api.Permission.Type result = io.etcd.jetcd.api.Permission.Type.valueOf(permType_);
      return result == null ? io.etcd.jetcd.api.Permission.Type.UNRECOGNIZED : result;
    }
    /**
     * <code>.authpb.Permission.Type permType = 1;</code>
     */
    public Builder setPermType(io.etcd.jetcd.api.Permission.Type value) {
      if (value == null) {
        throw new NullPointerException();
      }
      
      permType_ = value.getNumber();
      onChanged();
      return this;
    }
    /**
     * <code>.authpb.Permission.Type permType = 1;</code>
     */
    public Builder clearPermType() {
      
      permType_ = 0;
      onChanged();
      return this;
    }

    private com.google.protobuf.ByteString key_ = com.google.protobuf.ByteString.EMPTY;
    /**
     * <code>bytes key = 2;</code>
     */
    public com.google.protobuf.ByteString getKey() {
      return key_;
    }
    /**
     * <code>bytes key = 2;</code>
     */
    public Builder setKey(com.google.protobuf.ByteString value) {
      if (value == null) {
    throw new NullPointerException();
  }
  
      key_ = value;
      onChanged();
      return this;
    }
    /**
     * <code>bytes key = 2;</code>
     */
    public Builder clearKey() {
      
      key_ = getDefaultInstance().getKey();
      onChanged();
      return this;
    }

    private com.google.protobuf.ByteString rangeEnd_ = com.google.protobuf.ByteString.EMPTY;
    /**
     * <code>bytes range_end = 3;</code>
     */
    public com.google.protobuf.ByteString getRangeEnd() {
      return rangeEnd_;
    }
    /**
     * <code>bytes range_end = 3;</code>
     */
    public Builder setRangeEnd(com.google.protobuf.ByteString value) {
      if (value == null) {
    throw new NullPointerException();
  }
  
      rangeEnd_ = value;
      onChanged();
      return this;
    }
    /**
     * <code>bytes range_end = 3;</code>
     */
    public Builder clearRangeEnd() {
      
      rangeEnd_ = getDefaultInstance().getRangeEnd();
      onChanged();
      return this;
    }
    @java.lang.Override
    public final Builder setUnknownFields(
        final com.google.protobuf.UnknownFieldSet unknownFields) {
      return super.setUnknownFieldsProto3(unknownFields);
    }

    @java.lang.Override
    public final Builder mergeUnknownFields(
        final com.google.protobuf.UnknownFieldSet unknownFields) {
      return super.mergeUnknownFields(unknownFields);
    }


    // @@protoc_insertion_point(builder_scope:authpb.Permission)
  }

  // @@protoc_insertion_point(class_scope:authpb.Permission)
  private static final io.etcd.jetcd.api.Permission DEFAULT_INSTANCE;
  static {
    DEFAULT_INSTANCE = new io.etcd.jetcd.api.Permission();
  }

  public static io.etcd.jetcd.api.Permission getDefaultInstance() {
    return DEFAULT_INSTANCE;
  }

  private static final com.google.protobuf.Parser<Permission>
      PARSER = new com.google.protobuf.AbstractParser<Permission>() {
    @java.lang.Override
    public Permission parsePartialFrom(
        com.google.protobuf.CodedInputStream input,
        com.google.protobuf.ExtensionRegistryLite extensionRegistry)
        throws com.google.protobuf.InvalidProtocolBufferException {
      return new Permission(input, extensionRegistry);
    }
  };

  public static com.google.protobuf.Parser<Permission> parser() {
    return PARSER;
  }

  @java.lang.Override
  public com.google.protobuf.Parser<Permission> getParserForType() {
    return PARSER;
  }

  @java.lang.Override
  public io.etcd.jetcd.api.Permission getDefaultInstanceForType() {
    return DEFAULT_INSTANCE;
  }

}

