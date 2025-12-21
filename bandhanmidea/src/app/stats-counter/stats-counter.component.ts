import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stats-counter',
  templateUrl: './stats-counter.component.html',
  styleUrls: ['./stats-counter.component.css']
})
export class StatsCounterComponent implements OnInit {

  totalAll = 0;
  totalMale = 0;
  totalFemale = 0;
  totalMarriage = 0;

  ngOnInit(): void {
    this.animateValue('totalAll', 9598, 2000);
    this.animateValue('totalMale', 4251, 2000);
    this.animateValue('totalFemale', 5337, 2000);
    this.animateValue('totalMarriage', 2606, 2000);
  }

  animateValue(field: string, target: number, duration: number) {
    let start = 0;
    const stepTime = 10;
    const increment = target / (duration / stepTime);

    const interval = setInterval(() => {
      start += increment;
      (this as any)[field] = Math.floor(start);

      if (start >= target) {
        (this as any)[field] = target;
        clearInterval(interval);
      }
    }, stepTime);
  }
}
