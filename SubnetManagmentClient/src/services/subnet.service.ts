import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedList } from '../models/shared/paginated-list-dto';
import { GetSubnetDto } from '../models/get-subnet-dto';
import { SubnetDto } from '../models/subnet-dto';

@Injectable({
  providedIn: 'root',
})
export class SubnetService {
  private baseUrl = 'https://localhost:44366/api/Subnet';
  
  constructor(private http: HttpClient) {}

  addSubnet(subnetDto : SubnetDto): Observable<any> {
    return this.http.post<any>(this.baseUrl, subnetDto);
  }

  editSubnet(id: number, subnetDto : SubnetDto): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, subnetDto);
  }

  deleteSubnet(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }

  getSubnets(pageNumber: number, pageSize: number): Observable<PaginatedList<GetSubnetDto>> {
    const params = new HttpParams()
    .set('pageNumber', pageNumber.toString())
    .set('pageSize', pageSize.toString());
    return this.http.get<PaginatedList<GetSubnetDto>>(this.baseUrl, { params });
  }
}
