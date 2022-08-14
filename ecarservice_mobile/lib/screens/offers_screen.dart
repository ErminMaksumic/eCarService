import 'dart:ui';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutterv1/model/part.dart';
import 'package:flutterv1/providers/offer_provider.dart';
import 'package:flutterv1/screens/profile_screen.dart';
import 'package:flutterv1/screens/rating_screen.dart';
import 'package:flutterv1/utils/util.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../model/offer.dart';
import '../model/rating.dart';
import '../widgets/master_screen.dart';
import 'offer_details_screen.dart';

class OfferListScreen extends StatefulWidget {
  static const String routeName = "/offersList";
  const OfferListScreen({Key? key}) : super(key: key);

  @override
  State<OfferListScreen> createState() => _OfferListScreenState();
}

class _OfferListScreenState extends State<OfferListScreen> {
  OfferProvider? _offerProvider;
  List<Offer> data = [];

  final TextEditingController _searchController = TextEditingController();
  final TextEditingController _priceController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _offerProvider = context.read<OfferProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _offerProvider?.get(null);

    setState(() {
      data = tmpData!;
      loadPartsAndBrands();
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      index: 0,
      child: SingleChildScrollView(
        child: Column(children: buildAll()),
      ),
    );
  }

  List<Widget> buildAll() {
    List<Widget> list = <Widget>[];

    list.add(_buildHeader());
    list.add(_buildOfferSearch());
    list.addAll(_buildCard());

    return list;
  }

  List<Widget> _buildProductCardList() {
    if (data.isEmpty) {
      return [const Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Container(
              height: 200,
              width: 200,
              child: Column(
                children: [
                  Container(
                    height: 50,
                    width: 100,
                    child: imageFromBase64String(x.image!),
                  ),
                  Text(x.name ?? ""),
                  Text(formatNumber(x.price)),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }

  Widget _buildHeader() {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: const Text(
        "Offers",
        style: TextStyle(
            color: Colors.cyan, fontWeight: FontWeight.bold, fontSize: 40),
      ),
    );
  }

  Widget _buildOfferSearch() {
    return Column(
      children: [
        Row(
          children: [
            Expanded(
              child: Container(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                  child: TextField(
                    controller: _searchController,
                    /*onSubmitted: (value) async {
                      var tempData = await _offerProvider?.get({'name': value});
                      setState(() {
                        data = tempData!;
                      });
                    },*/
                    decoration: const InputDecoration(
                        hintText: "Name",
                        prefixIcon: Icon(Icons.search),
                        border: OutlineInputBorder(
                          borderSide: BorderSide(color: Colors.grey),
                        )),
                  )),
            ),
            Expanded(
              child: Container(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
                  child: TextField(
                    // onSubmitted: (value) async {
                    //   var tempData = await _offerProvider?.get({'name': value});
                    //   setState(() {
                    //     data = tempData!;
                    //   });
                    // },
                    controller: _priceController,
                    decoration: InputDecoration(
                        hintText: "Price",
                        prefixIcon: const Icon(Icons.money),
                        border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(10),
                          borderSide: const BorderSide(color: Colors.grey),
                        )),
                    keyboardType: TextInputType.number,
                  )),
            ),
          ],
        ),
        Container(
          padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          child: IconButton(
            icon: Icon(Icons.filter_list),
            color: Colors.cyan,
            onPressed: () async {
              var tempData = await _offerProvider?.get({
                'name': _searchController.text,
                'price':
                    _priceController.text.isNotEmpty ? _priceController.text : 0
              });
              setState(() {
                data = tempData!;
                loadPartsAndBrands();
              });
            },
          ),
        ),
        // //delete this after testing !
        // Container(
        //   padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
        //   child: IconButton(
        //     icon: Icon(Icons.abc_sharp),
        //     color: Colors.cyan,
        //     onPressed: () async {
        //       await Navigator.pushNamed(context, RatingScreen.routeName);
        //     },
        //   ),
        // )
      ],
    );
  }

  List<Widget> _buildCard() {
    if (data.length == 0) {
      return [const Text("Loading data")];
    } else if (data != null && (data[0].threeBrands == null)) {
      return [const Text("Loading brands and parts")];
    }

    ;

    List<Widget> list = data
        .map(
          (x) => Padding(
            padding: const EdgeInsets.all(10.0),
            child: Container(
              color: Colors.cyan,
              child: Container(
                  child: Stack(
                children: [
                  Column(
                    children: [
                      Container(
                        height: 110,
                        width: 500,
                        child: Image.memory(dataFromBase64String(x.image!),
                            fit: BoxFit.cover),
                      ),
                      Container(
                        height: 130,
                        child: Column(
                          children: [
                            Row(
                              mainAxisAlignment: MainAxisAlignment.center,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  x.name!,
                                  textAlign: TextAlign.center,
                                  style: const TextStyle(
                                      color: Colors.black,
                                      fontWeight: FontWeight.bold,
                                      fontSize: 25),
                                ),
                              ],
                            ),
                            SizedBox(height: 10),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const LimitedBox(
                                  child: Text("- Included parts: ",
                                      overflow: TextOverflow.ellipsis,
                                      textAlign: TextAlign.center,
                                      style: TextStyle(
                                          color: Colors.black,
                                          fontWeight: FontWeight.bold,
                                          fontSize: 15)),
                                ),
                                Text(
                                  x.parts!.length >= 3
                                      ? "${x.threeParts!.take(3).toString()}, ..."
                                      : x.parts!.length < 3 &&
                                              x.parts!.isNotEmpty
                                          ? x.partNames!
                                          : "Not specified",
                                  textAlign: TextAlign.center,
                                  style: const TextStyle(
                                      color: Colors.red,
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                              ],
                            ),
                            const SizedBox(
                              height: 5,
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const LimitedBox(
                                  child: Text("- For brands: ",
                                      overflow: TextOverflow.ellipsis,
                                      textAlign: TextAlign.center,
                                      style: TextStyle(
                                          color: Colors.black,
                                          fontWeight: FontWeight.bold,
                                          fontSize: 15)),
                                ),
                                Text(
                                  x.carBrands!.length >= 3
                                      ? "${x.threeBrands!.take(3).toString()}, ..."
                                      : x.carBrands!.length < 3 &&
                                              x.carBrands!.isNotEmpty
                                          ? x.carBrandNames!
                                          : "Not specified",
                                  textAlign: TextAlign.center,
                                  style: const TextStyle(
                                      color: Colors.red,
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                              ],
                            ),
                            const SizedBox(
                              height: 5,
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "- Price: ",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: Colors.black,
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                Text("${formatNumber(x.price)} \$",
                                    textAlign: TextAlign.center,
                                    style: const TextStyle(
                                        color: Colors.deepOrange,
                                        fontWeight: FontWeight.bold,
                                        fontSize: 15))
                              ],
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.end,
                              children: [
                                InkWell(
                                  onTap: () {
                                    Navigator.pushNamed(context,
                                        "${OfferDetailsScreen.routeName}/${x.offerId}");
                                  },
                                  child: const Text(
                                    "More info",
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                        color: Colors.black,
                                        fontWeight: FontWeight.bold,
                                        fontSize: 15),
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ],
              )),
            ),
          ),
        )
        .cast<Widget>()
        .toList();
    return list;
  }

  loadPartsAndBrands() {
    for (var element in data) {
      element.threeBrands = element.carBrandNames!.split(",");
      element.threeParts = element.partNames!.split(",");
    }
  }
}
