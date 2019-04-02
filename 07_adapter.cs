interface IApi {
    string request(string params);
}

class Api : IApi {
    public string request(string params) {
        return "{ response: 1 }";
    }
}

class OldApi: IApi {
    public XmlDocument specificRequest(XmlDocument params) {
        return new XmlDocument("<Response>2</Response>");
    }
}

class OldApiAdapter: IApi {
    private OldApi api;

    public OldApiAdapter(OldApi api) {
        this.api = api
    }

    public string request(string params) {

        XmlDocument xml = this.parseJsonToXml(params);

        XmlDocument response = api.specificRequest(xml);

        return this.parseXmlToJson(response);
    }

    private parseJsonToXml(string json) {
        return; //...
    }


    private parseXmlToJson(XmlDocument xml) {
        return; //...
    }
}


IApi api = new Api();
IApi oldApi = new OldApiAdapter(new OldApi())();

