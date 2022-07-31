// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'brand.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CarBrand _$CarBrandFromJson(Map<String, dynamic> json) => CarBrand()
  ..carBrandId = json['carBrandId'] as int?
  ..name = json['name'] as String?
  ..carServiceId = json['carServiceId'] as int?;

Map<String, dynamic> _$CarBrandToJson(CarBrand instance) => <String, dynamic>{
      'carBrandId': instance.carBrandId,
      'name': instance.name,
      'carServiceId': instance.carServiceId,
    };
