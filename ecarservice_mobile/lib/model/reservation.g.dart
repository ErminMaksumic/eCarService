// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reservation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reservation _$ReservationFromJson(Map<String, dynamic> json) => Reservation()
  ..reservationId = json['reservationId'] as int?
  ..status = json['status'] as String?
  ..userId = json['userId'] as int?
  ..offerId = json['offerId'] as int?
  ..paymentId = json['paymentId'] as int?
  ..carBrandId = json['carBrandId'] as int?
  ..additionalServices = (json['additionalServices'] as List<dynamic>?)
      ?.map((e) => AdditionalService.fromJson(e as Map<String, dynamic>))
      .toList();

Map<String, dynamic> _$ReservationToJson(Reservation instance) =>
    <String, dynamic>{
      'reservationId': instance.reservationId,
      'status': instance.status,
      'userId': instance.userId,
      'offerId': instance.offerId,
      'paymentId': instance.paymentId,
      'carBrandId': instance.carBrandId,
      'additionalServices': instance.additionalServices,
    };
