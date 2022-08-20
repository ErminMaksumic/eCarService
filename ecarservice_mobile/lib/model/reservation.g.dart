// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reservation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reservation _$ReservationFromJson(Map<String, dynamic> json) => Reservation()
  ..reservationId = json['reservationId'] as int?
  ..userId = json['userId'] as int?
  ..offerId = json['offerId'] as int?
  ..paymentId = json['paymentId'] as int?
  ..carBrandId = json['carBrandId'] as int?
  ..date = json['date'] as String?
  ..additionalServices = (json['additionalServices'] as List<dynamic>?)
      ?.map((e) => AdditionalService.fromJson(e as Map<String, dynamic>))
      .toList();

Map<String, dynamic> _$ReservationToJson(Reservation instance) =>
    <String, dynamic>{
      'reservationId': instance.reservationId,
      'userId': instance.userId,
      'offerId': instance.offerId,
      'paymentId': instance.paymentId,
      'carBrandId': instance.carBrandId,
      'date': instance.date,
      'additionalServices': instance.additionalServices,
    };
