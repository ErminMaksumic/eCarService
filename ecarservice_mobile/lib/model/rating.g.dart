// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'rating.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Rating _$RatingFromJson(Map<String, dynamic> json) => Rating()
  ..ratingId = json['ratingId'] as int?
  ..rate = json['rate'] as int?
  ..comment = json['comment'] as String?
  ..offerId = json['offerId'] as int?
  ..userId = json['userId'] as int?;

Map<String, dynamic> _$RatingToJson(Rating instance) => <String, dynamic>{
      'ratingId': instance.ratingId,
      'rate': instance.rate,
      'comment': instance.comment,
      'offerId': instance.offerId,
      'userId': instance.userId,
    };
