resource "aws_lambda_function" "this" {
  filename      = data.archive_file.this.output_path
  function_name = var.function_name
  role          = aws_iam_role.this.arn
  handler       = var.handler
  timeout       = 300

  source_code_hash = data.archive_file.this.output_base64sha256

  runtime = var.runtime
}

data "archive_file" "this" {
  type        = "zip"
  source_dir = "${path.module}/../app/src/${var.function_name}/bin/Release/net6.0"
  output_path = "${path.module}/artefatos/net6.0.zip"
}