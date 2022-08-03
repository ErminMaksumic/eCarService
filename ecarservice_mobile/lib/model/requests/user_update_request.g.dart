// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_update_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserUpdateRequest _$UserUpdateRequestFromJson(Map<String, dynamic> json) =>
    UserUpdateRequest()
      ..password = json['password'] as String?
      ..passwordConfirmation = json['passwordConfirmation'] as String?
      ..image = json['image'] as String?;

Map<String, dynamic> _$UserUpdateRequestToJson(UserUpdateRequest instance) =>
    <String, dynamic>{
      'password': instance.password,
      'passwordConfirmation': instance.passwordConfirmation,
      'image': instance.image,
    };
