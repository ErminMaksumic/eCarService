import 'package:flutter/material.dart';
import 'package:flutterv1/model/customOfferRequest.dart';
import 'package:flutterv1/providers/car_service_provider.dart';
import 'package:flutterv1/providers/custom_offer_provider.dart';
import 'package:flutterv1/providers/offer_provider.dart';
import 'package:flutterv1/providers/rating_provider.dart';
import 'package:flutterv1/providers/user_provider.dart';
import 'package:flutterv1/screens/custom_offer_req_screen.dart';
import 'package:flutterv1/screens/login_screen.dart';
import 'package:flutterv1/screens/offer_details_screen.dart';
import 'package:flutterv1/screens/offers_screen.dart';
import 'package:flutterv1/screens/profile_screen.dart';
import 'package:flutterv1/screens/rating_screen.dart';
import 'package:flutterv1/screens/register_screen.dart';
import 'package:flutterv1/utils/util.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => OfferProvider()),
      ChangeNotifierProvider(create: (_) => UserProvider()),
      ChangeNotifierProvider(create: (_) => RatingProvider()),
      ChangeNotifierProvider(create: (_) => CarServiceProvider()),
      ChangeNotifierProvider(create: (_) => CustomOfferRequestProvider()),
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
          return MaterialPageRoute(builder: (context) => const ProfileScreen());
        }
        if (settings.name == RatingScreen.routeName) {
          return MaterialPageRoute(builder: (context) => const RatingScreen());
        }
        if (settings.name == CustomOfferReqScreen.routeName) {
          return MaterialPageRoute(
              builder: (context) => const CustomOfferReqScreen());
        }

        // dynamic uri for sending url with id
        var uri = Uri.parse(settings.name!);
        if ("/${uri.pathSegments.first}" == OfferDetailsScreen.routeName) {
          var id = uri.pathSegments[1];
          return MaterialPageRoute(
              builder: (context) => OfferDetailsScreen(id));
        }
      },
    );
  }
}
