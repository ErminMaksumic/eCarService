import 'dart:convert';
import 'dart:typed_data';
import 'dart:ui';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';
import 'dart:io' as Io;


class Authorization {
  static String? username;
  static String? password;
}

Image imageFromBase64String(String base64String) {
  return Image.memory(base64Decode(base64String));
}

Uint8List dataFromBase64String(String base64String) {
  return base64Decode(base64String);
}

String base64String(Uint8List data) {
  return base64Encode(data);
}

String formatNumber(dynamic)
{
  if(dynamic == null)
  {
    return '';
  }
  var f = NumberFormat('###.00');
  return f.format(dynamic);
}

