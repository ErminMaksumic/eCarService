// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'customOfferRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CustomOfferRequest _$CustomOfferRequestFromJson(Map<String, dynamic> json) =>
    CustomOfferRequest()
      ..customReqId = json['customReqId'] as int?
      ..name = json['name'] as String?
      ..status = json['status'] as String?
      ..description = json['description'] as String?
      ..carServiceId = json['carServiceId'] as int?
      ..userId = json['userId'] as int?
      ..date = json['date'] as String;

Map<String, dynamic> _$CustomOfferRequestToJson(CustomOfferRequest instance) =>
    <String, dynamic>{
      'customReqId': instance.customReqId,
      'name': instance.name,
      'status': instance.status,
      'description': instance.description,
      'carServiceId': instance.carServiceId,
      'userId': instance.userId,
      'date': instance.date,
    };
