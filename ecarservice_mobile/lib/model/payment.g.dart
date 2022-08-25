// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'payment.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Payment _$PaymentFromJson(Map<String, dynamic> json) => Payment()
  ..paymentId = json['paymentId'] as int?
  ..fullName = json['fullName'] as String?
  ..amount = (json['amount'] as num?)?.toDouble()
  ..date = json['date'] as String?;

Map<String, dynamic> _$PaymentToJson(Payment instance) => <String, dynamic>{
      'paymentId': instance.paymentId,
      'fullName': instance.fullName,
      'amount': instance.amount,
      'date': instance.date,
    };
