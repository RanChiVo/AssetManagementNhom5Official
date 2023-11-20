## Quy định

**Áp dụng kể từ lần merge code kế tiếp (sau commit [80b44f]), ai đang vi phạm trong đợt merge code
lần này phải sửa lại nếu muốn được merge lần kế tiếp**

Các trường hợp sẽ không nhận code:

- Build chương trình lỗi, chỗ nào lỗi chưa làm xong thì comment lại
- Đặt tên bảng, thuộc tính, component quá chung chung (Vd như Asset thì nên đổi thành AssetX với X là tên nhóm để không bị trùng...)
- Sai permission: Check trong các file appservice của aspcore (Phần lớn sai do copy cái MenuClient qua mà không chịu sửa lại)

Tất cả các trường hợp vi phạm không được merge sẽ **xem như là chưa làm**


## Checkout

- Update database and run host
    - Open visual studio
    - Choose ...MVC.Host as default project
    - Build and run
    - Open package manager console
    ```
    Update-Database
    ```

- Run application
```
npm install # if needed
npm start
```

checkout -> ~~rename server~~ ->
Update-Database -> run web.host ->
~~refresh~~ -> npm start

## Update server name in config files when checking out
- Copy all files in `hooks/` to `.git/hooks/`


[80b44f]: https://github.com/catrom/AssetManagement/commit/80b44f661266a59e70b9bd4c01853757862d71aa
