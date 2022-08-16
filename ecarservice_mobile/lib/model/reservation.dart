import 'package:flutterv1/model/additionalService.dart';
import 'package:json_annotation/json_annotation.dart';
part 'reservation.g.dart';

@JsonSerializable()
class Reservation {
  int? reservationId;
  String? status;
  int? userId;
  int? offerId;
  int? paymentId;
  int? carBrandId;
  List<AdditionalService>? additionalServices;

  Reservation() {}

  factory Reservation.fromJson(Map<String, dynamic> json) =>
      _$ReservationFromJson(json);

  /// Connect the generated [_$RatingToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ReservationToJson(this);
}
