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

  Future<List<AdditionalService>> getRecommendedItems(int addServiceId) async {
    var url = "$baseUrl/recommend/$addServiceId";

    var uri = Uri.parse(url);
    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<AdditionalService>().toList();
    } else {
      throw Exception("An error occurred!");
    }
  }
}
