// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'offer.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Offer _$OfferFromJson(Map<String, dynamic> json) => Offer()
  ..name = json['name'] as String?
  ..status = json['status'] as String?
  ..image = json['image'] as String?
  ..price = (json['price'] as num?)?.toDouble()
  ..parts = (json['parts'] as List<dynamic>?)
      ?.map((e) => Part.fromJson(e as Map<String, dynamic>))
      .toList();

Map<String, dynamic> _$OfferToJson(Offer instance) => <String, dynamic>{
      'name': instance.name,
      'status': instance.status,
      'image': instance.image,
      'price': instance.price,
      'parts': instance.parts,
    };
