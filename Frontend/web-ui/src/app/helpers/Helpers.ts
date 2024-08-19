import { Injectable } from "@angular/core";

@Injectable({providedIn:'root'})
export class Helpers
{
    static ParseFilterVmToUrl(filterVm : any)
    {
      let searchString = "";
      let index = 0;
      for (const [key, value] of Object.entries(filterVm)) {
        if(index == 0)
        {
          searchString += "?" + `${key}` + "=" + `${value}`;
        } else
        {
          searchString += "&" + `${key}` + "=" + `${value}`;
        }
        index++;
      }
      return searchString
    }


    static ConvertToLocalTime(dateTime : any)
    {
        let date = new Date(dateTime +"Z");
        return  date.toLocaleDateString()+" "+ date.toLocaleTimeString();
    }

    static GetTodayDate()
    {
      let date = new Date();
      return date.toLocaleDateString();
    }

}
