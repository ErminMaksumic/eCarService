// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'additionalService.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AdditionalService _$AdditionalServiceFromJson(Map<String, dynamic> json) =>
    AdditionalService()
      ..additionalServiceId = json['additionalServiceId'] as int?
      ..name = json['name'] as String?
      ..description = json['description'] as String?
      ..price = (json['price'] as num?)?.toDouble();

Map<String, dynamic> _$AdditionalServiceToJson(AdditionalService instance) =>
    <String, dynamic>{
      'additionalServiceId': instance.additionalServiceId,
      'name': instance.name,
      'description': instance.description,
      'price': instance.price,
    };
