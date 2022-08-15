import 'package:flutterv1/model/brand.dart';
import 'package:flutterv1/model/part.dart';
import 'package:flutterv1/screens/offers/offers_screen.dart';

import 'package:json_annotation/json_annotation.dart';
part 'customOfferRequest.g.dart';

@JsonSerializable()
class CustomOfferRequest {
  int? customReqId;
  String? name;
  String? status;
  String? description;
  int? carServiceId;
  int? userId;
  String? date;

  CustomOfferRequest() {}

  factory CustomOfferRequest.fromJson(Map<String, dynamic> json) =>
      _$CustomOfferRequestFromJson(json);

  /// Connect the generated [_$CustomOfferRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CustomOfferRequestToJson(this);
}
