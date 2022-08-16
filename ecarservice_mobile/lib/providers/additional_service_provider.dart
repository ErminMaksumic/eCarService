import 'dart:convert';
import 'dart:io';
import 'package:flutter/cupertino.dart';
import 'package:flutterv1/model/additionalService.dart';
import 'package:flutterv1/providers/base_provider.dart';
import 'package:http/io_client.dart';
import '../model/rating.dart';

class AdditionalServiceProvider extends BaseProvider<AdditionalService> {
  AdditionalServiceProvider() : super("AdditionalService");

  @override
  AdditionalService fromJson(data) {
    return AdditionalService.fromJson(data);
  }
}
