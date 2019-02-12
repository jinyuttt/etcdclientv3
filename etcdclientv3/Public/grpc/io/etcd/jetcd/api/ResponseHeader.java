// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: rpc.proto

package io.etcd.jetcd.api;

/**
 * Protobuf type {@code etcdserverpb.ResponseHeader}
 */
public  final class ResponseHeader extends
    com.google.protobuf.GeneratedMessageV3 implements
    // @@protoc_insertion_point(message_implements:etcdserverpb.ResponseHeader)
    ResponseHeaderOrBuilder {
private static final long serialVersionUID = 0L;
  // Use ResponseHeader.newBuilder() to construct.
  private ResponseHeader(com.google.protobuf.GeneratedMessageV3.Builder<?> builder) {
    super(builder);
  }
  private ResponseHeader() {
    clusterId_ = 0L;
    memberId_ = 0L;
    revision_ = 0L;
    raftTerm_ = 0L;
  }

  @java.lang.Override
  public final com.google.protobuf.UnknownFieldSet
  getUnknownFields() {
    return this.unknownFields;
  }
  private ResponseHeader(
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

            clusterId_ = input.readUInt64();
            break;
          }
          case 16: {

            memberId_ = input.readUInt64();
            break;
          }
          case 24: {

            revision_ = input.readInt64();
            break;
          }
          case 32: {

            raftTerm_ = input.readUInt64();
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
    return io.etcd.jetcd.api.JetcdProto.internal_static_etcdserverpb_ResponseHeader_descriptor;
  }

  @java.lang.Override
  protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
      internalGetFieldAccessorTable() {
    return io.etcd.jetcd.api.JetcdProto.internal_static_etcdserverpb_ResponseHeader_fieldAccessorTable
        .ensureFieldAccessorsInitialized(
            io.etcd.jetcd.api.ResponseHeader.class, io.etcd.jetcd.api.ResponseHeader.Builder.class);
  }

  public static final int CLUSTER_ID_FIELD_NUMBER = 1;
  private long clusterId_;
  /**
   * <pre>
   * cluster_id is the ID of the cluster which sent the response.
   * </pre>
   *
   * <code>uint64 cluster_id = 1;</code>
   */
  public long getClusterId() {
    return clusterId_;
  }

  public static final int MEMBER_ID_FIELD_NUMBER = 2;
  private long memberId_;
  /**
   * <pre>
   * member_id is the ID of the member which sent the response.
   * </pre>
   *
   * <code>uint64 member_id = 2;</code>
   */
  public long getMemberId() {
    return memberId_;
  }

  public static final int REVISION_FIELD_NUMBER = 3;
  private long revision_;
  /**
   * <pre>
   * revision is the key-value store revision when the request was applied.
   * </pre>
   *
   * <code>int64 revision = 3;</code>
   */
  public long getRevision() {
    return revision_;
  }

  public static final int RAFT_TERM_FIELD_NUMBER = 4;
  private long raftTerm_;
  /**
   * <pre>
   * raft_term is the raft term when the request was applied.
   * </pre>
   *
   * <code>uint64 raft_term = 4;</code>
   */
  public long getRaftTerm() {
    return raftTerm_;
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
    if (clusterId_ != 0L) {
      output.writeUInt64(1, clusterId_);
    }
    if (memberId_ != 0L) {
      output.writeUInt64(2, memberId_);
    }
    if (revision_ != 0L) {
      output.writeInt64(3, revision_);
    }
    if (raftTerm_ != 0L) {
      output.writeUInt64(4, raftTerm_);
    }
    unknownFields.writeTo(output);
  }

  @java.lang.Override
  public int getSerializedSize() {
    int size = memoizedSize;
    if (size != -1) return size;

    size = 0;
    if (clusterId_ != 0L) {
      size += com.google.protobuf.CodedOutputStream
        .computeUInt64Size(1, clusterId_);
    }
    if (memberId_ != 0L) {
      size += com.google.protobuf.CodedOutputStream
        .computeUInt64Size(2, memberId_);
    }
    if (revision_ != 0L) {
      size += com.google.protobuf.CodedOutputStream
        .computeInt64Size(3, revision_);
    }
    if (raftTerm_ != 0L) {
      size += com.google.protobuf.CodedOutputStream
        .computeUInt64Size(4, raftTerm_);
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
    if (!(obj instanceof io.etcd.jetcd.api.ResponseHeader)) {
      return super.equals(obj);
    }
    io.etcd.jetcd.api.ResponseHeader other = (io.etcd.jetcd.api.ResponseHeader) obj;

    boolean result = true;
    result = result && (getClusterId()
        == other.getClusterId());
    result = result && (getMemberId()
        == other.getMemberId());
    result = result && (getRevision()
        == other.getRevision());
    result = result && (getRaftTerm()
        == other.getRaftTerm());
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
    hash = (37 * hash) + CLUSTER_ID_FIELD_NUMBER;
    hash = (53 * hash) + com.google.protobuf.Internal.hashLong(
        getClusterId());
    hash = (37 * hash) + MEMBER_ID_FIELD_NUMBER;
    hash = (53 * hash) + com.google.protobuf.Internal.hashLong(
        getMemberId());
    hash = (37 * hash) + REVISION_FIELD_NUMBER;
    hash = (53 * hash) + com.google.protobuf.Internal.hashLong(
        getRevision());
    hash = (37 * hash) + RAFT_TERM_FIELD_NUMBER;
    hash = (53 * hash) + com.google.protobuf.Internal.hashLong(
        getRaftTerm());
    hash = (29 * hash) + unknownFields.hashCode();
    memoizedHashCode = hash;
    return hash;
  }

  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
      java.nio.ByteBuffer data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
      java.nio.ByteBuffer data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
      com.google.protobuf.ByteString data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
      com.google.protobuf.ByteString data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(byte[] data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
      byte[] data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input, extensionRegistry);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseDelimitedFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseDelimitedFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input, extensionRegistry);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
      com.google.protobuf.CodedInputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static io.etcd.jetcd.api.ResponseHeader parseFrom(
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
  public static Builder newBuilder(io.etcd.jetcd.api.ResponseHeader prototype) {
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
   * Protobuf type {@code etcdserverpb.ResponseHeader}
   */
  public static final class Builder extends
      com.google.protobuf.GeneratedMessageV3.Builder<Builder> implements
      // @@protoc_insertion_point(builder_implements:etcdserverpb.ResponseHeader)
      io.etcd.jetcd.api.ResponseHeaderOrBuilder {
    public static final com.google.protobuf.Descriptors.Descriptor
        getDescriptor() {
      return io.etcd.jetcd.api.JetcdProto.internal_static_etcdserverpb_ResponseHeader_descriptor;
    }

    @java.lang.Override
    protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
        internalGetFieldAccessorTable() {
      return io.etcd.jetcd.api.JetcdProto.internal_static_etcdserverpb_ResponseHeader_fieldAccessorTable
          .ensureFieldAccessorsInitialized(
              io.etcd.jetcd.api.ResponseHeader.class, io.etcd.jetcd.api.ResponseHeader.Builder.class);
    }

    // Construct using io.etcd.jetcd.api.ResponseHeader.newBuilder()
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
      clusterId_ = 0L;

      memberId_ = 0L;

      revision_ = 0L;

      raftTerm_ = 0L;

      return this;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.Descriptor
        getDescriptorForType() {
      return io.etcd.jetcd.api.JetcdProto.internal_static_etcdserverpb_ResponseHeader_descriptor;
    }

    @java.lang.Override
    public io.etcd.jetcd.api.ResponseHeader getDefaultInstanceForType() {
      return io.etcd.jetcd.api.ResponseHeader.getDefaultInstance();
    }

    @java.lang.Override
    public io.etcd.jetcd.api.ResponseHeader build() {
      io.etcd.jetcd.api.ResponseHeader result = buildPartial();
      if (!result.isInitialized()) {
        throw newUninitializedMessageException(result);
      }
      return result;
    }

    @java.lang.Override
    public io.etcd.jetcd.api.ResponseHeader buildPartial() {
      io.etcd.jetcd.api.ResponseHeader result = new io.etcd.jetcd.api.ResponseHeader(this);
      result.clusterId_ = clusterId_;
      result.memberId_ = memberId_;
      result.revision_ = revision_;
      result.raftTerm_ = raftTerm_;
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
      if (other instanceof io.etcd.jetcd.api.ResponseHeader) {
        return mergeFrom((io.etcd.jetcd.api.ResponseHeader)other);
      } else {
        super.mergeFrom(other);
        return this;
      }
    }

    public Builder mergeFrom(io.etcd.jetcd.api.ResponseHeader other) {
      if (other == io.etcd.jetcd.api.ResponseHeader.getDefaultInstance()) return this;
      if (other.getClusterId() != 0L) {
        setClusterId(other.getClusterId());
      }
      if (other.getMemberId() != 0L) {
        setMemberId(other.getMemberId());
      }
      if (other.getRevision() != 0L) {
        setRevision(other.getRevision());
      }
      if (other.getRaftTerm() != 0L) {
        setRaftTerm(other.getRaftTerm());
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
      io.etcd.jetcd.api.ResponseHeader parsedMessage = null;
      try {
        parsedMessage = PARSER.parsePartialFrom(input, extensionRegistry);
      } catch (com.google.protobuf.InvalidProtocolBufferException e) {
        parsedMessage = (io.etcd.jetcd.api.ResponseHeader) e.getUnfinishedMessage();
        throw e.unwrapIOException();
      } finally {
        if (parsedMessage != null) {
          mergeFrom(parsedMessage);
        }
      }
      return this;
    }

    private long clusterId_ ;
    /**
     * <pre>
     * cluster_id is the ID of the cluster which sent the response.
     * </pre>
     *
     * <code>uint64 cluster_id = 1;</code>
     */
    public long getClusterId() {
      return clusterId_;
    }
    /**
     * <pre>
     * cluster_id is the ID of the cluster which sent the response.
     * </pre>
     *
     * <code>uint64 cluster_id = 1;</code>
     */
    public Builder setClusterId(long value) {
      
      clusterId_ = value;
      onChanged();
      return this;
    }
    /**
     * <pre>
     * cluster_id is the ID of the cluster which sent the response.
     * </pre>
     *
     * <code>uint64 cluster_id = 1;</code>
     */
    public Builder clearClusterId() {
      
      clusterId_ = 0L;
      onChanged();
      return this;
    }

    private long memberId_ ;
    /**
     * <pre>
     * member_id is the ID of the member which sent the response.
     * </pre>
     *
     * <code>uint64 member_id = 2;</code>
     */
    public long getMemberId() {
      return memberId_;
    }
    /**
     * <pre>
     * member_id is the ID of the member which sent the response.
     * </pre>
     *
     * <code>uint64 member_id = 2;</code>
     */
    public Builder setMemberId(long value) {
      
      memberId_ = value;
      onChanged();
      return this;
    }
    /**
     * <pre>
     * member_id is the ID of the member which sent the response.
     * </pre>
     *
     * <code>uint64 member_id = 2;</code>
     */
    public Builder clearMemberId() {
      
      memberId_ = 0L;
      onChanged();
      return this;
    }

    private long revision_ ;
    /**
     * <pre>
     * revision is the key-value store revision when the request was applied.
     * </pre>
     *
     * <code>int64 revision = 3;</code>
     */
    public long getRevision() {
      return revision_;
    }
    /**
     * <pre>
     * revision is the key-value store revision when the request was applied.
     * </pre>
     *
     * <code>int64 revision = 3;</code>
     */
    public Builder setRevision(long value) {
      
      revision_ = value;
      onChanged();
      return this;
    }
    /**
     * <pre>
     * revision is the key-value store revision when the request was applied.
     * </pre>
     *
     * <code>int64 revision = 3;</code>
     */
    public Builder clearRevision() {
      
      revision_ = 0L;
      onChanged();
      return this;
    }

    private long raftTerm_ ;
    /**
     * <pre>
     * raft_term is the raft term when the request was applied.
     * </pre>
     *
     * <code>uint64 raft_term = 4;</code>
     */
    public long getRaftTerm() {
      return raftTerm_;
    }
    /**
     * <pre>
     * raft_term is the raft term when the request was applied.
     * </pre>
     *
     * <code>uint64 raft_term = 4;</code>
     */
    public Builder setRaftTerm(long value) {
      
      raftTerm_ = value;
      onChanged();
      return this;
    }
    /**
     * <pre>
     * raft_term is the raft term when the request was applied.
     * </pre>
     *
     * <code>uint64 raft_term = 4;</code>
     */
    public Builder clearRaftTerm() {
      
      raftTerm_ = 0L;
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


    // @@protoc_insertion_point(builder_scope:etcdserverpb.ResponseHeader)
  }

  // @@protoc_insertion_point(class_scope:etcdserverpb.ResponseHeader)
  private static final io.etcd.jetcd.api.ResponseHeader DEFAULT_INSTANCE;
  static {
    DEFAULT_INSTANCE = new io.etcd.jetcd.api.ResponseHeader();
  }

  public static io.etcd.jetcd.api.ResponseHeader getDefaultInstance() {
    return DEFAULT_INSTANCE;
  }

  private static final com.google.protobuf.Parser<ResponseHeader>
      PARSER = new com.google.protobuf.AbstractParser<ResponseHeader>() {
    @java.lang.Override
    public ResponseHeader parsePartialFrom(
        com.google.protobuf.CodedInputStream input,
        com.google.protobuf.ExtensionRegistryLite extensionRegistry)
        throws com.google.protobuf.InvalidProtocolBufferException {
      return new ResponseHeader(input, extensionRegistry);
    }
  };

  public static com.google.protobuf.Parser<ResponseHeader> parser() {
    return PARSER;
  }

  @java.lang.Override
  public com.google.protobuf.Parser<ResponseHeader> getParserForType() {
    return PARSER;
  }

  @java.lang.Override
  public io.etcd.jetcd.api.ResponseHeader getDefaultInstanceForType() {
    return DEFAULT_INSTANCE;
  }

}

