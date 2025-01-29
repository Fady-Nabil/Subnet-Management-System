import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetIPAddressDto } from '../models/get-ipadress-dto';
import { IpAddressDto } from '../models/ipadress-dto';

@Injectable({
  providedIn: 'root',
})
export class IpService {
  private baseUrl = 'https://localhost:44366/api/IPAddress';

  constructor(private http: HttpClient) {}

  getIpsBySubnet(subnetId: number): Observable<GetIPAddressDto[]> {
    return this.http.get<GetIPAddressDto[]>(`${this.baseUrl}/subnet/${subnetId}`);
  }

  addIp(ipAddressDto: IpAddressDto): Observable<any> {
    return this.http.post<any>(this.baseUrl, ipAddressDto);
  }

  editIp(id: number, ipAddressDto: IpAddressDto): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, ipAddressDto);
  }

  deleteIp(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }
}
