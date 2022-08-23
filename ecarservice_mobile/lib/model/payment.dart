import 'package:json_annotation/json_annotation.dart';
part 'payment.g.dart';

@JsonSerializable()
class Payment {
  int? paymentId;
  String? fullName;
  double? amount;
  String? date;

  Payment() {}

  factory Payment.fromJson(Map<String, dynamic> json) =>
      _$PaymentFromJson(json);

  /// Connect the generated [_$PartToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PaymentToJson(this);
}
