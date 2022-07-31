import 'package:json_annotation/json_annotation.dart';
part 'brand.g.dart';


@JsonSerializable()
class CarBrand{
  int? carBrandId;
  String? name;
  int? carServiceId;

  CarBrand(){}


 factory CarBrand.fromJson(Map<String, dynamic> json) => _$CarBrandFromJson(json);

  /// Connect the generated [_$OfferToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CarBrandToJson(this);
}