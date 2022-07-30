import 'package:flutterv1/model/part.dart';
import 'package:flutterv1/screens/offers_screen.dart';

import 'package:json_annotation/json_annotation.dart';
part 'offer.g.dart';

@JsonSerializable()
class Offer{
  String? name;
  String? status;
  String? image;
  double? price;
  List<Part>? parts;

  Offer(){}


  factory Offer.fromJson(Map<String, dynamic> json) => _$OfferFromJson(json);

  /// Connect the generated [_$OfferToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$OfferToJson(this);
}
