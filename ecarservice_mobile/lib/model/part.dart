import 'package:flutterv1/screens/offers/offers_screen.dart';

import 'package:json_annotation/json_annotation.dart';
part 'part.g.dart';

@JsonSerializable()
class Part{
  int? partId;
  String? name;
  int? quantity;
  int? carServiceId;

  Part(){}

  factory Part.fromJson(Map<String, dynamic> json) => _$PartFromJson(json);

  /// Connect the generated [_$PartToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PartToJson(this);
}