import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'arabicDate'
})
export class ArabicDatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    const days = ['الأحد', 'الإثنين', 'الثلاثاء', 'الأربعاء', 'الخميس', 'الجمعة', 'السبت'];
    const months = ['كانون الثاني', 'شباط', 'آذار', 'نيسان', 'أيار', 'حزيران', 'تموز', 'آب', 'أيلول', 'تشرين الأول', 'تشرين الثاني', 'كانون الأول'];

    const date = new Date(value);
    const day = days[date.getDay()];
    const year = date.getFullYear();
    const month = months[date.getMonth()];
    const dayOfMonth = date.getDate();

    return `${day} في ${dayOfMonth}/${month}/${year}`;
  }

}
