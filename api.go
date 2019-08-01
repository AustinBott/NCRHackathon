//http://localhost:61325/api/db/demo_jj185175/CSO_Marche_22-8/printer_status
package main

import (
    "encoding/json"
    "fmt"
    "io/ioutil"
    "log"
    "net/http"
    "os"
)

type Response struct {
    Namespace string `json: "Namespace"`
    EntityId string `json: "EntityId"`
    Date string `json: "Date"`
    MetricTitle string `json: MetricTitle`
    MetricValue int `json: MetricValue`
    MetricStatus int `json: MetricStatus`
}


func main() {
    response, err := http.Get("http://billgatespersonalcomputer.centralus.cloudapp.azure.com:8080/api/db/demo_jj185175/CSO_Marche_22-8/printer_status")
    
    if err != nil {
        fmt.Print(err.Error())
        os.Exit(1)
    }

    responseData, err := ioutil.ReadAll(response.Body
    if err != nil {
        log.Fatal(err)
    }
    
    //fmt.Println(string(responseData))

    var responseObject Response
    json.Unmarshal(responseData, &responseObject)

    var status int = responseObject.MetricStatus

    if status == 0 {
        fmt.Println(responseObject.MetricTitle)
        fmt.Println(responseObject.MetricValue)
        fmt.Println("OK")
        os.Exit(0)
    } else if status == 1 {
        fmt.Println(responseObject.MetricTitle)
        fmt.Println(responseObject.MetricValue)
        fmt.Println("Regular")
        os.Exit(1)
    } else if status == 2 {
        fmt.Println(responseObject.MetricTitle)
        fmt.Println(responseObject.MetricValue)
        fmt.Println("Warning")
        os.Exit(2)
    }
}
