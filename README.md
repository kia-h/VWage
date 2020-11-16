# Virtual Wage

This is a C#  Windows  console  application  that  allows  a  user  to  enter  a  gross  salary  package  and  a  pay frequency and then showthem a breakdown of this salary and what their pay packet will be.
### Details:

  - User will be asked to enter gross package, the gross package is inclusive of superannuation
  - User will be asked to enter a pay frequency (weekly, fortnightly or monthly) 
  - Salary breakdown will show:
    - Gross package (annual)
    - Superannuation contribution (annual)
    - Taxable income (annual)
    - List of deductions and their annual amount, deductions included:
        -  Medicare Levy
        - Budget Repair Levy 
        - Income tax
    -  Net income (annual)
    - Pay packet amount
- Application needs to cater for invalid user entry gracefully
- Application should format values as currency
  

### Example Output
```
Enter your salary package amount: 65000Enter 
your pay frequency (W for weekly, F for fortnightly, M for monthly): M

Calculating salary details...

Gross package: $65,000
Superannuation: $5,639.27

Taxable income: $59,360.73

Deductions:
Medicare Levy: $1,188.00
Budget Repair Levy: $0
Income Tax: $10,839.00

Net income: $47,333.73
Pay packet: $3,944.48 per month

Press any key to end...
```