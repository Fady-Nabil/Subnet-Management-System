import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IpService } from '../../services/ip.service';
import { GetIPAddressDto } from '../../models/get-ipadress-dto';
import { MatDialog } from '@angular/material/dialog';
import { AddIpAddressComponent } from './add-ip-address/add-ip-address.component';
import { IpAddressDto } from '../../models/ipadress-dto';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-ip-list',
  standalone: false,
  
  templateUrl: './ip-list.component.html',
  styleUrl: './ip-list.component.css'
})
export class IpListComponent {
  ipAddresses: GetIPAddressDto[] = [];
  subnetId!: number;
  subnetName: string = '';
  isLoading: boolean = true;

  constructor(private route: ActivatedRoute,
    private dialog: MatDialog,
    private snackBar: MatSnackBar, 
    private ipService: IpService) {}

  ngOnInit(): void {
    this.subnetId = +this.route.snapshot.paramMap.get('subnetId')!;
    this.route.queryParams.subscribe((queryParams) => {
      this.subnetName = queryParams['subnetName'] || '';
    });
    this.loadIps();
  }

  loadIps() {
    this.ipService.getIpsBySubnet(this.subnetId).subscribe((ips) => {
      this.ipAddresses = ips;
      this.isLoading = false;
    });
  }

  addIp() {
    console.log('Add IP');
  }

  editIp(ipId: number) {
    console.log('Edit IP:', ipId);
  }

  deleteIp(ipId: number) {
    this.ipService.deleteIp(ipId).subscribe(() => {
      this.loadIps();
    });
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(AddIpAddressComponent, {
      width: '400px',
      data: { ipAddressValue: '', subnetId: this.subnetId },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        result.createdUserId = 2;
        this.ipService.addIp(result).subscribe(() => {
          this.showAlert('IP added successfully.')
          this.loadIps();
        });
      }
    });
  }

  openEditDialog(id : number, ip: IpAddressDto): void {
    const dialogRef = this.dialog.open(AddIpAddressComponent, {
      width: '400px',
      data: { ...ip },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        const updatedIp = { ...ip, ...result };
        updatedIp.subnetId = this.subnetId;
        updatedIp.createdUserId = 2;
        this.ipService.editIp(id, updatedIp).subscribe(() => {
          this.showAlert('IP updated successfully.')
          this.loadIps();
        });
      }
    });
  }

  deleteIpAddress(ipId: number): void {
    if (confirm('Are you sure you want to delete this IP address?')) {
      this.ipService.deleteIp(ipId).subscribe(() => {
        this.showAlert('IP deleted successfully.')
        this.loadIps(); 
      });
    }
  }

  showAlert(message: string, action: string = 'Close') {
    this.snackBar.open(message, action, {
      duration: 3000, 
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
  }

}
