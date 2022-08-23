import 'dart:convert';
import 'dart:io';
import 'dart:io' as Io;
import 'dart:typed_data';
import 'dart:ui';
import 'package:flutter/cupertino.dart';
import 'package:flutterv1/model/additionalService.dart';
import 'package:flutterv1/providers/additional_service_provider.dart';
import 'package:flutterv1/providers/reservation_provider.dart';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart' hide Card;
import 'package:flutterv1/model/offer.dart';
import 'package:flutterv1/screens/user/login_screen.dart';
import 'package:flutterv1/utils/user.dart';
import 'package:image_picker/image_picker.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';
import '../../main.dart';
import '../../model/requests/user_insert_request.dart';
import '../../providers/offer_provider.dart';
import '../../providers/payment.dart';
import '../../providers/user_provider.dart';
import '../../utils/util.dart';

class ReservationScreen extends StatefulWidget {
  static const String routeName = "/reservation";
  String id;
  ReservationScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ReservationScreen> createState() => _ReservationScreenState();
}

class _ReservationScreenState extends State<ReservationScreen> {
  late OfferProvider _offerProvider;
  late ReservationProvider _reservationProvider;
  late AdditionalServiceProvider _additionalServiceProvider;
  late PaymentProvider _paymentProvider;
  Offer? _data;
  List<AdditionalService>? _additionalServices = [];
  List<AdditionalService>? _recommendedServices = [];
  int? selectedCarBrand;
  String? selectedDate;
  String? expDate;
  Map<String, dynamic>? paymentIntentData;
  final _formKey = GlobalKey<FormState>();
  List<int> valuesIds = [];
  List<AdditionalService>? valuesObjects = [];
  double amount = 0;

  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _descriptionController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _offerProvider = context.read<OfferProvider>();
    _reservationProvider = context.read<ReservationProvider>();
    _additionalServiceProvider = context.read<AdditionalServiceProvider>();
    _paymentProvider = context.read<PaymentProvider>();
    Stripe.publishableKey =
        "pk_test_51LXsy4GXcNCijvMXdjVDqB7K28efOhBim1tVizcvkuGHE38cF421qwVvF1FSEFMIYQFVxiUjCLk7FX6hMu0sYdIq00Zwp0NpCA";
    setState(() {});
    loadData();
  }

  void loadData() async {
    var tempData = await _offerProvider.getById(int.parse(widget.id));
    var tempAddServices = await _additionalServiceProvider.get();
    setState(() {
      _data = tempData;
      _additionalServices = tempAddServices;
    });

    _firstNameController.text = UserLogin.user!.firstName!;
    _lastNameController.text = UserLogin.user!.lastName!;
  }

  @override
  Widget build(BuildContext context) {
    if (_data == null) {
      return const Text('Loading...');
    }
    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          child: Column(
            children: [
              SizedBox(
                height: 200,
                width: 500,
                child: Image.memory(dataFromBase64String(_data!.image!),
                    fit: BoxFit.cover),
              ),
              Container(
                margin: EdgeInsets.only(top: 20),
                child: Center(
                  child: Center(
                      child: Text(
                    "Reservation for offer : ${_data!.name!}",
                    style: const TextStyle(
                        color: Colors.cyan,
                        fontSize: 25,
                        fontWeight: FontWeight.bold),
                  )),
                ),
              ),
              const SizedBox(
                height: 35,
              ),
              Container(
                child: Form(
                  key: _formKey,
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  child: Column(
                    children: [
                      Container(
                        child: DropdownButton(
                            items: _buildBrands(),
                            value: selectedCarBrand,
                            hint: Text("Select your car brand:"),
                            onChanged: (dynamic value) {
                              setState(() {
                                selectedCarBrand = value;
                              });
                            }),
                      ),
                      SizedBox(height: 15),
                      ElevatedButton(
                        onPressed: () => _selectDate(context),
                        child: Text(selectedDate != null
                            ? "${selectedDate}"
                            : 'Select date for your reservation'),
                      ),
                      Row(
                        children: [
                          Container(
                            margin: EdgeInsets.only(top: 15),
                            width: MediaQuery.of(context).size.width / 2,
                            padding: const EdgeInsets.all(10),
                            child: TextFormField(
                              validator: (value) {
                                if (value!.isEmpty) {
                                  return "Required field!";
                                }
                              },
                              decoration: const InputDecoration(
                                  labelText: "First name",
                                  labelStyle: TextStyle(color: Colors.cyan),
                                  enabledBorder: OutlineInputBorder(
                                      borderSide: BorderSide(
                                          width: 1, color: Colors.cyan))),
                              controller: _firstNameController,
                            ),
                          ),
                          Container(
                            margin: EdgeInsets.only(top: 15),
                            width: MediaQuery.of(context).size.width / 2,
                            padding: const EdgeInsets.all(8),
                            child: TextFormField(
                              validator: (value) {
                                if (value!.isEmpty) {
                                  return "Required field!";
                                }
                              },
                              decoration: const InputDecoration(
                                  labelText: "Last name",
                                  labelStyle: TextStyle(color: Colors.cyan),
                                  enabledBorder: OutlineInputBorder(
                                      borderSide: BorderSide(
                                          width: 1, color: Colors.cyan))),
                              controller: _lastNameController,
                            ),
                          ),
                        ],
                      ),
                      Container(
                        width: 300,
                        height: 200,
                        child: Card(
                          margin: const EdgeInsets.only(top: 40),
                          color: Color.fromARGB(255, 54, 52, 52),
                          child: Container(
                            decoration: const BoxDecoration(
                                border: Border(
                                    top: BorderSide(color: Colors.cyan),
                                    bottom: BorderSide(color: Colors.cyan),
                                    right: BorderSide(color: Colors.cyan),
                                    left: BorderSide(color: Colors.cyan))),
                            padding: const EdgeInsets.all(8.0),
                            child: TextFormField(
                              controller: _descriptionController,
                              maxLines: 5, //or null,
                              decoration: const InputDecoration.collapsed(
                                  hintText: "Note (OPTIONAL)",
                                  hintStyle: TextStyle(color: Colors.cyan)),
                            ),
                          ),
                        ),
                      ),
                      SizedBox(height: 20),
                      Column(
                        children: _buildAddServices(),
                      ),
                      SizedBox(height: 20),
                      Container(
                        height: 50,
                        margin: EdgeInsets.fromLTRB(50, 20, 50, 0),
                        decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(10),
                            gradient: const LinearGradient(
                                colors: [Colors.cyan, Colors.blue])),
                        child: InkWell(
                          onTap: () async {
                            makePayment(calculateAmount(_data!.price!));
                          },
                          child: const Center(child: Text("Reserve offer")),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  List<DropdownMenuItem> _buildBrands() {
    if (_data!.carBrands!.isEmpty) {
      return [];
    }
    List<DropdownMenuItem> list = <DropdownMenuItem>[];

    list.add(const DropdownMenuItem(
      enabled: false,
      value: -1,
      child:
          Text("Select the car brand", style: TextStyle(color: Colors.black)),
    ));

    list.addAll(_data!.carBrands!
        .map((x) => DropdownMenuItem(
              value: x.carBrandId,
              child: Text(x.name!, style: const TextStyle(color: Colors.white)),
            ))
        .toList());

    return list;
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        initialDate: DateTime.now(),
        firstDate: DateTime(2015, 8),
        lastDate: DateTime(2101));

    if (picked != null && picked != selectedDate) {
      setState(() {
        String formated = DateFormat('yyyy-MM-dd').format(picked);
        selectedDate = formated;
      });
    }
  }

  Future<void> makePayment(double amount) async {
    try {
      if (_formKey.currentState!.validate() &&
          selectedDate != null &&
          selectedCarBrand != null) {
        paymentIntentData =
            await createPaymentIntent((amount * 100).round().toString(), 'usd');
        var response = await Stripe.instance
            .initPaymentSheet(
                paymentSheetParameters: SetupPaymentSheetParameters(
                    paymentIntentClientSecret:
                        paymentIntentData!['client_secret'],
                    applePay: true,
                    googlePay: true,
                    testEnv: true,
                    style: ThemeMode.dark,
                    merchantCountryCode: 'BIH',
                    merchantDisplayName: 'eCarService'))
            .then((value) {});

        displayPaymentSheet();
      } else {
        throw Exception("Please check your inputs!");
      }
    } on Exception catch (e) {
      showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
                title: const Text("Error ocurred"),
                content: Text(e.toString()),
                actions: [
                  TextButton(
                    child: const Text("Ok"),
                    onPressed: () => Navigator.pop(context),
                  )
                ],
              ));
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance
          .presentPaymentSheet(
              parameters: PresentPaymentSheetParameters(
        clientSecret: paymentIntentData!['client_secret'],
        confirmPayment: true,
      ))
          .onError((error, stackTrace) {
        throw Exception(error);
      });

      createReservationPayment();
      ScaffoldMessenger.of(context)
          .showSnackBar(const SnackBar(content: Text("Payment successful")));
    } on Exception catch (e) {
      showDialog(
          context: context,
          builder: (_) => AlertDialog(
                title: Text("Error ocurred"),
                content: Text("Payment canceled!"),
              ));
    } catch (e) {
      print('$e');
    }
  }

  createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
          Uri.parse('https://api.stripe.com/v1/payment_intents'),
          body: body,
          headers: {
            'Authorization':
                'Bearer sk_test_51LXsy4GXcNCijvMXEp1OFQ2cqnKjCTdRO9dhriLoWOA6HhHdRRNz1v65O1pVShh9o4ZJEddVQl798crxgj2jrUoU00oOSFGK71',
            'Content-Type': 'application/x-www-form-urlencoded'
          });
      return jsonDecode(response.body);
    } catch (err) {
      print('Error: ${err.toString()}');
    }
  }

  _buildAddServices() {
    if (_additionalServices!.length == 0) {
      return [const Text("Loading data")];
    }

    List<int>? addServiceIds = [];

    _recommendedServices!.forEach((element) {
      addServiceIds!.add(element.additionalServiceId!);
    });

    List<Widget> list = _additionalServices!
        .map(
          (x) => Center(
            child: CheckboxListTile(
              title: Text(x.name!),
              subtitle: addServiceIds!.indexOf(x.additionalServiceId!) > -1
                  ? Text(
                      x.price!.toString() + "\$ - We recommend you this offer!")
                  : Text(x.price!.toString() + "\$"),
              secondary: const Icon(Icons.car_rental),
              autofocus: false,
              isThreeLine: true,
              activeColor: Colors.green,
              checkColor: Colors.white,
              value: valuesIds.indexOf(x.additionalServiceId!) != -1
                  ? true
                  : false,
              onChanged: (bool? value) {
                setState(() {
                  if (value! == true) {
                    loadRecommendedServices(x.additionalServiceId);
                    valuesIds.add(x.additionalServiceId!);
                    valuesObjects!.add(x);
                  } else {
                    valuesIds.remove(x.additionalServiceId);
                    valuesObjects!.remove(x);
                  }
                });
              },
            ),
          ),
        )
        .cast<Widget>()
        .toList();
    return list;
  }

  Future loadRecommendedServices(id) async {
    var tempData = await _additionalServiceProvider.getRecommendedItems(id);

    setState(() {
      _recommendedServices = tempData;
    });
  }

  void createReservationPayment() async {
    var reservation = await _reservationProvider.insert({
      'date': selectedDate,
      'userId': UserLogin.user!.userId,
      'offerId': _data!.offerId,
      'carBrandId': selectedCarBrand,
      'status': "active",
      'note': "active",
      'additionalServices': valuesIds,
      'payment': {
        'transactionId': paymentIntentData!['id'],
        'amount': calculateAmount(_data!.price!),
        'date': DateFormat('yyyy-MM-dd').format(DateTime.now()),
        'fullName': _firstNameController.text + " " + _lastNameController.text
      }
    });
  }

  double calculateAmount(double offerPrice) {
    double addServicesAmount = 0;
    valuesObjects!.forEach((element) {
      addServicesAmount += element.price!;
    });

    return addServicesAmount + offerPrice;
  }
}
