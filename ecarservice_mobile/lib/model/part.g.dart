// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'part.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Part _$PartFromJson(Map<String, dynamic> json) => Part()
  ..partId = json['partId'] as int?
  ..name = json['name'] as String?
  ..quantity = json['quantity'] as int?
  ..carServiceId = json['carServiceId'] as int?;

Map<String, dynamic> _$PartToJson(Part instance) => <String, dynamic>{
      'partId': instance.partId,
      'name': instance.name,
      'quantity': instance.quantity,
      'carServiceId': instance.carServiceId,
    };
