import { Component, OnInit } from '@angular/core';
import { GetSubnetDto } from '../../models/get-subnet-dto';
import { PaginatedList } from '../../models/shared/paginated-list-dto';
import { SubnetService } from '../../services/subnet.service';
import { SubnetDto } from '../../models/subnet-dto';
import { MatDialog } from '@angular/material/dialog';
import { AddSubnetComponent } from './add-subnet/add-subnet.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-subnet-list',
  standalone: false,
  
  templateUrl: './subnet-list.component.html',
  styleUrl: './subnet-list.component.css'
})
export class SubnetListComponent implements OnInit {
  subnets: GetSubnetDto[] = [];
  totalCount: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;

  constructor(private subnetService: SubnetService,
    private snackBar: MatSnackBar,
    private router: Router,
    private dialog: MatDialog) {}

  ngOnInit() {
    this.loadSubnets(this.currentPage, this.pageSize);
  }

  loadSubnets(pageNumber: number, pageSize: number): void {
    this.subnetService.getSubnets(pageNumber, pageSize).subscribe((data: PaginatedList<GetSubnetDto>) => {
      this.subnets = data.items;
      this.totalCount = data.totalCount;
      this.pageSize = data.pageSize;
      this.currentPage = data.currentPage;
    });
  }

  onPageChange(event: any): void {
    this.loadSubnets(event.pageIndex + 1, event.pageSize);
  }

  addNewSubnet(): void {
    const dialogRef = this.dialog.open(AddSubnetComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadSubnets(this.currentPage, this.pageSize);
      }
    });
  }

  openAddSubnetDialog(): void {
    const dialogRef = this.dialog.open(AddSubnetComponent, {
      width: '400px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        result.createdUserId = 2;
        this.subnetService.addSubnet(result).subscribe(() => {
          this.loadSubnets(this.currentPage, this.pageSize);
        });
      }
    });
  }

  openEditSubnetDialog(id : number, subnet: GetSubnetDto): void {
    const dialogRef = this.dialog.open(AddSubnetComponent, {
      width: '400px',
      data: subnet, 
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        const updatedSubnet = { ...subnet, ...result };
        this.subnetService.editSubnet(id, updatedSubnet).subscribe(() => {
          this.loadSubnets(this.currentPage, this.pageSize);
        });
      }
    });
  }

  deleteSubnet(subnetId: number): void {
    if (confirm('Are you sure you want to delete this subnet?')) {
      this.subnetService.deleteSubnet(subnetId).subscribe(() => {
        this.showAlert('Subnet deleted successfully.')
        this.loadSubnets(this.currentPage, this.pageSize);
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

  openIpAddressPage(subnet: GetSubnetDto): void {
    this.router.navigate([`/subnets/${subnet.subnetId}/ips`], {
      queryParams: { subnetName: subnet.subnetName },
    });
  }

}
