import 'package:flutterv1/model/additionalService.dart';
import 'package:json_annotation/json_annotation.dart';

import 'offer.dart';
part 'reservation.g.dart';

@JsonSerializable()
class Reservation {
  int? reservationId;
  int? userId;
  int? offerId;
  int? paymentId;
  int? carBrandId;
  String? status;
  String? date;
  Offer? offer;
  List<AdditionalService>? additionalServices;

  Reservation() {}

  factory Reservation.fromJson(Map<String, dynamic> json) =>
      _$ReservationFromJson(json);

  /// Connect the generated [_$RatingToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ReservationToJson(this);
}
