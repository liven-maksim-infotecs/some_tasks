import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public statistics: Array<DeviceStatistic> = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DeviceStatistic[]>(baseUrl + 'api/Statistic').subscribe(this.updateStatistic);
  }

  updateStatistic(result: DeviceStatistic[]){
    console.log(result)
    this.statistics = result;
  }
}

interface DeviceStatistic {
  id: string;
  appVersion: number;
  username: number;
  osType: string;
}
