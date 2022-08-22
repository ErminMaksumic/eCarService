import 'dart:convert';
import 'dart:io';
import 'package:flutter/cupertino.dart';
import 'package:flutterv1/model/additionalService.dart';
import 'package:flutterv1/providers/base_provider.dart';
import 'package:http/io_client.dart';
import '../model/rating.dart';
import '../model/reservation.dart';

class ReservationProvider extends BaseProvider<Reservation> {
  ReservationProvider() : super("Reservation");

  @override
  Reservation fromJson(data) {
    return Reservation.fromJson(data);
  }

 
}
