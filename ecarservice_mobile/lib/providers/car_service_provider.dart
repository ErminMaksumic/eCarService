import 'dart:convert';
import 'dart:io';
import 'package:flutter/cupertino.dart';
import 'package:flutterv1/model/carService.dart';
import 'package:flutterv1/model/customOfferRequest.dart';
import 'package:flutterv1/providers/base_provider.dart';
import 'package:http/io_client.dart';

class CarServiceProvider extends BaseProvider<CarService> {
  CarServiceProvider() : super("CarService");

  @override
  CarService fromJson(data) {
    return CarService.fromJson(data);
  }
}
