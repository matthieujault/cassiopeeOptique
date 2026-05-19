import requests

NOM_LENTILLE="LA2024"


url = "https://www.thorlabs.com/graphql"

headers = {
    "Content-Type": "application/json",
    "User-Agent": "Mozilla/5.0"
}

payload = {
    "operationName": "SearchFamilyProducts",
    "variables": {
        "storeId": "Thorlabs-Website",
        "cultureName": "en-US",
        "currencyCode": "EUR",

        # Put the lenses you want here
        "productIds": [
            NOM_LENTILLE

        ]
    },

    "query": """

    query SearchFamilyProducts(
      $storeId: String!,
      $currencyCode: String!,
      $cultureName: String!,
      $productIds: [String!]!
    ) {

      familyProducts(
        storeId: $storeId
        currencyCode: $currencyCode
        cultureName: $cultureName
        productIds: $productIds
      ) {

        code
        fallbackName

        assets {
          name
          url
          group
        }
      }
    }
    """

}

response = requests.post(
    url,
    json=payload,
    headers=headers
)

data = response.json()

products = data["data"]["familyProducts"]

for product in products:

    code = product["code"]
    name = product["fallbackName"]

    step_url = None
    blueprint=None

    for asset in product["assets"]:
        if asset["group"].lower() == "step":
            step_url = asset["url"]
            break
    for asset in product["assets"]:
        if asset["group"].lower() == "CAD PDF".lower():
            blueprint = asset["url"]
            break
        

def to_mm(value, unit):
    if unit == '"':   # inches
        return float(value) * 25.4
    return float(value)
def parse_number(text):
    text = text.strip()

    # handle mm
    if "mm" in text:
        val = text.replace("mm", "").strip()
        return float(val), "mm"

    # handle inches "
    if '"' in text:
        val = text.replace('"', "").strip()
        if "/" in val:
            num, den = val.split("/")
            val= float(num) / float(den)
        return float(val), '"'

    return None
def parse_name(name):
    parts = [p.strip() for p in name.split(",")]

    result = {
        "diameter_mm": None,
        "focal_length_mm": None,
        "name": name
    }

    for p in parts:
        # diameter (Ø or Ø encoded)
        if "Ø" in p or "&#216;" in p:
            p = p.replace("&#216;", "").replace("Ø", "").strip()
            parsed = parse_number(p)
            if parsed:
                val, unit = parsed
                result["diameter_mm"] = to_mm(val, unit)

        # focal length
        elif "f =" in p:
            val_part = p.split("f =")[1].strip()
            parsed = parse_number(val_part)
            if parsed:
                val, unit = parsed
                result["focal_length_mm"] = to_mm(val, unit)

    return result


res = parse_name(name)
res["code"]=code
res["blueprint_url"]=blueprint
res["step"]=step_url

print(res)


