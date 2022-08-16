import 'dart:io';
import 'dart:io' as Io;
import 'dart:typed_data';
import 'dart:ui';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
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
  late UserProvider _userProvider;
  late OfferProvider _offerProvider;
  Offer? _data;
  int? selectedCarBrand;
  String? selectedDate;
  String? expDate;

  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _descriptionController = TextEditingController();
  final TextEditingController _fullNameController = TextEditingController();
  final TextEditingController _cardNumberController = TextEditingController();
  final TextEditingController _expDateController = TextEditingController();

  final _formKey = GlobalKey<FormState>();

  String? imageString;
  File? image;

  @override
  void initState() {
    super.initState();
    _offerProvider = context.read<OfferProvider>();
    setState(() {});
    loadData();
  }

  void loadData() async {
    var tempData = await _offerProvider.getById(int.parse(widget.id));
    setState(() {
      _data = tempData;
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
                      Container(
                        margin: EdgeInsets.only(top: 20),
                        child: const Center(
                          child: Center(
                              child: Text(
                            "Payment",
                            style: TextStyle(
                                color: Colors.cyan,
                                fontSize: 25,
                                fontWeight: FontWeight.bold),
                          )),
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 15),
                        padding: const EdgeInsets.all(8),
                        child: TextFormField(
                          validator: (value) {
                            if (value!.isEmpty) {
                              return "Required field!";
                            }
                          },
                          decoration: const InputDecoration(
                              labelText: "Full name",
                              labelStyle: TextStyle(color: Colors.cyan),
                              enabledBorder: OutlineInputBorder(
                                  borderSide: BorderSide(
                                      width: 1, color: Colors.cyan))),
                          controller: _fullNameController,
                        ),
                      ),
                      Container(
                        margin: EdgeInsets.only(top: 15),
                        padding: const EdgeInsets.all(8),
                        child: TextFormField(
                          decoration: const InputDecoration(
                              labelText: "Card number",
                              hintText: "00/00",
                              hintStyle: TextStyle(color: Colors.red),
                              labelStyle: TextStyle(color: Colors.cyan),
                              enabledBorder: OutlineInputBorder(
                                  borderSide: BorderSide(
                                      width: 1, color: Colors.cyan))),
                          controller: _fullNameController,
                        ),
                      ),
                      Row(
                        children: [
                          // Container(
                          //   width: MediaQuery.of(context).size.width / 2,
                          //   height: MediaQuery.of(context).size.height * 0.1,
                          //   padding: const EdgeInsets.all(8),
                          //   child: ButtonTheme(
                          //     minWidth: 500.0,
                          //     height: 180.0,
                          //     child: ElevatedButton(
                          //       onPressed: () => _selectDate(context),
                          //       child: Text(expDate != null
                          //           ? "${expDate}"
                          //           : 'Exp date'),
                          //     ),
                          //   ),
                          // ),
                          Container(
                            padding: const EdgeInsets.all(8),
                            width: MediaQuery.of(context).size.width / 2,
                            margin: EdgeInsets.only(top: 15),
                            child: TextFormField(
                              decoration: const InputDecoration(
                                  labelText: "Exp date",
                                  labelStyle: TextStyle(color: Colors.cyan),
                                  enabledBorder: OutlineInputBorder(
                                      borderSide: BorderSide(
                                          width: 1, color: Colors.cyan))),
                              controller: _expDateController,
                            ),
                          ),
                          Container(
                            padding: const EdgeInsets.all(8),
                            width: MediaQuery.of(context).size.width / 2,
                            margin: EdgeInsets.only(top: 15),
                            child: TextFormField(
                              decoration: const InputDecoration(
                                  labelText: "CCV",
                                  labelStyle: TextStyle(color: Colors.cyan),
                                  enabledBorder: OutlineInputBorder(
                                      borderSide: BorderSide(
                                          width: 1, color: Colors.cyan))),
                              controller: _fullNameController,
                            ),
                          ),
                        ],
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
                            if (_formKey.currentState!.validate()) {}
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
}
