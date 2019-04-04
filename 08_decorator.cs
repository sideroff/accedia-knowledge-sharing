String fileName = @"C:\temp\MyFile.txt";
 
FileInfo file = new FileInfo(fileName);

// make sure the directory exists.
file.Directory.Create();


using (;FileStream fileStream = file.Create()) {
    using (BufferedStream bufferedStream = new BufferedStream(fileStream, 1000)) {

        for (int index = 1; index < 2000; index++) {
            byte[] bytes = Encoding.UTF8.GetBytes(string.Format("Line {0} \n", index));

            // automatically flushes to file when bytes reach 1000
            bufferedStream.Write(bytes, 0, bytes.Length);
        }

        // Flushing the remaining data in the buffer to the file.
        bufferedStream.Flush();
    } 
}
