// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'carService.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CarService _$CarServiceFromJson(Map<String, dynamic> json) => CarService()
  ..carServiceId = json['carServiceId'] as int?
  ..name = json['name'] as String?
  ..address = json['address'] as String?
  ..dateCreated = json['dateCreated'] == null
      ? null
      : DateTime.parse(json['dateCreated'] as String)
  ..phoneNumber = json['phoneNumber'] as String?
  ..userId = json['userId'] as int?;

Map<String, dynamic> _$CarServiceToJson(CarService instance) =>
    <String, dynamic>{
      'carServiceId': instance.carServiceId,
      'name': instance.name,
      'address': instance.address,
      'dateCreated': instance.dateCreated?.toIso8601String(),
      'phoneNumber': instance.phoneNumber,
      'userId': instance.userId,
    };
