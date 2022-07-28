// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User()
  ..userId = json['userId'] as int?
  ..userName = json['userName'] as String?
  ..email = json['email'] as String?
  ..firstName = json['firstName'] as String?
  ..lastName = json['lastName'] as String?
  ..fullName = json['fullName'] as String?
  ..image = json['image'] as String?
  ..roleId = json['roleId'] as int?;

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'userId': instance.userId,
      'userName': instance.userName,
      'email': instance.email,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'fullName': instance.fullName,
      'image': instance.image,
      'roleId': instance.roleId,
    };
