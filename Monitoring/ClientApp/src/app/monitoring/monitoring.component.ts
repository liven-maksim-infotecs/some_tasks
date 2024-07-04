import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-monitoring',
  templateUrl: './monitoring.component.html'
})
export class MonitoringComponent {
  public statistics: Array<DeviceStatistic> = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.statistics = [];
    http.get<DeviceStatistic[]>(baseUrl + 'api/Statistic').subscribe((result) => {
      this.statistics = result;
    });
  }
}

interface DeviceStatistic {
  id: string;
  appVersion: number;
  username: number;
  osType: string;
}
