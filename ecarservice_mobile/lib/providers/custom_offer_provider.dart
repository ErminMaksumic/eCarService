import 'dart:convert';
import 'dart:io';
import 'package:flutter/cupertino.dart';
import 'package:flutterv1/model/customOfferRequest.dart';
import 'package:flutterv1/providers/base_provider.dart';
import 'package:http/io_client.dart';


class CustomOfferRequestProvider extends BaseProvider<CustomOfferRequest> {
  CustomOfferRequestProvider() : super("CustomOfferRequest");

  @override 
  CustomOfferRequest fromJson(data){
   return CustomOfferRequest.fromJson(data);
  }
} 