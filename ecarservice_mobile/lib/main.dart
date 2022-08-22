import 'package:flutter/material.dart';
import 'package:flutterv1/providers/additional_service_provider.dart';
import 'package:flutterv1/providers/car_service_provider.dart';
import 'package:flutterv1/providers/custom_offer_provider.dart';
import 'package:flutterv1/providers/offer_provider.dart';
import 'package:flutterv1/providers/payment.dart';
import 'package:flutterv1/providers/rating_provider.dart';
import 'package:flutterv1/providers/reservation_provider.dart';
import 'package:flutterv1/providers/user_provider.dart';
import 'package:flutterv1/screens/custom_offer/custom_offer_req_screen.dart';
import 'package:flutterv1/screens/user/login_screen.dart';
import 'package:flutterv1/screens/offers/offer_details_screen.dart';
import 'package:flutterv1/screens/offers/offers_screen.dart';
import 'package:flutterv1/screens/user/profile_screen.dart';
import 'package:flutterv1/screens/offers/rating_screen.dart';
import 'package:flutterv1/screens/user/register_screen.dart';
import 'package:flutterv1/utils/util.dart';
import 'package:provider/provider.dart';

import 'screens/reservation/reservation_screen.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => OfferProvider()),
      ChangeNotifierProvider(create: (_) => UserProvider()),
      ChangeNotifierProvider(create: (_) => RatingProvider()),
      ChangeNotifierProvider(create: (_) => CarServiceProvider()),
      ChangeNotifierProvider(create: (_) => CustomOfferRequestProvider()),
      ChangeNotifierProvider(create: (_) => ReservationProvider()),
      ChangeNotifierProvider(create: (_) => AdditionalServiceProvider()),
      ChangeNotifierProvider(create: (_) => PaymentProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        title: 'eCarService',
        theme: ThemeData(
          primaryColor: Colors.cyan,
          brightness: Brightness.dark,
        ),
        home: LoginScreen(),
        onGenerateRoute: (settings) {
          if (settings.name == OfferListScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => const OfferListScreen());
          }
          if (settings.name == RegistrationScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => const RegistrationScreen());
          }
          if (settings.name == LoginScreen.routeName) {
            return MaterialPageRoute(builder: (context) => const MyApp());
          }
          if (settings.name == ProfileScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => const ProfileScreen());
          }
          if (settings.name == CustomOfferReqScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => const CustomOfferReqScreen());
          }

          // dynamic uri for sending url with id
          var uri = Uri.parse(settings.name!);
          var id = uri.pathSegments[1];
          if ("/${uri.pathSegments.first}" == OfferDetailsScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => OfferDetailsScreen(id));
          } else if ("/${uri.pathSegments.first}" == RatingScreen.routeName) {
            return MaterialPageRoute(builder: (context) => RatingScreen(id));
          } else if ("/${uri.pathSegments.first}" ==
              ReservationScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => ReservationScreen(id));
          }
        });
  }
}
