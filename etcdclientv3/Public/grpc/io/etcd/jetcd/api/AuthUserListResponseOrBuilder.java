// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: rpc.proto

package io.etcd.jetcd.api;

public interface AuthUserListResponseOrBuilder extends
    // @@protoc_insertion_point(interface_extends:etcdserverpb.AuthUserListResponse)
    com.google.protobuf.MessageOrBuilder {

  /**
   * <code>.etcdserverpb.ResponseHeader header = 1;</code>
   */
  boolean hasHeader();
  /**
   * <code>.etcdserverpb.ResponseHeader header = 1;</code>
   */
  io.etcd.jetcd.api.ResponseHeader getHeader();
  /**
   * <code>.etcdserverpb.ResponseHeader header = 1;</code>
   */
  io.etcd.jetcd.api.ResponseHeaderOrBuilder getHeaderOrBuilder();

  /**
   * <code>repeated string users = 2;</code>
   */
  java.util.List<java.lang.String>
      getUsersList();
  /**
   * <code>repeated string users = 2;</code>
   */
  int getUsersCount();
  /**
   * <code>repeated string users = 2;</code>
   */
  java.lang.String getUsers(int index);
  /**
   * <code>repeated string users = 2;</code>
   */
  com.google.protobuf.ByteString
      getUsersBytes(int index);
}
